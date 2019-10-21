namespace Carnival.eGangway.Mobile.Service
{
    using Carnival.eGangway.Mobile.Service.Instrumentation;
    using Carnival.eGangway.Mobile.Service.Interface;
    using Carnival.eGangway.Mobile.Service.Repository;
    using Filter;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ILoggerFactory LoggerFactory { get; }
        public ILoginCounter LoginCounter { get; }
        public ICacheService CacheService { get; }

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory, ILoginCounter loginCounter, ICacheService cacheService)
        {
            Configuration = configuration;
            LoggerFactory = loggerFactory;
            LoginCounter = loginCounter;
            CacheService = cacheService;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add<InstrumentationActionContextAttribute>();
            })
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var hostConfig = new HostConfiguration();
            Configuration.Bind("HostConfigurationSettings", hostConfig);

            services.AddSingleton(hostConfig);
            services.AddSingleton<ILoginCounter, LoginCounterService>();
            
            //services.AddSingleton<ICacheService, CacheService>();
            //services.AddSingleton<ICacheService, CacheDBContext>();

            services.AddTransient<ILoginService, LoginService>((provider) => new LoginService(Configuration, LoginCounter));
            services.AddTransient<ICrewLoginService, CrewLoginService>((provider) => new CrewLoginService(Configuration, LoginCounter));
            services.AddTransient<IShipService, ShipService>((provider) => new ShipService(Configuration));
            services.AddTransient<IDashboardService, DashboardService>((provider) => new DashboardService(Configuration));
            services.AddTransient<IPersonService, PersonService>((provider) => new PersonService(Configuration));
            services.AddTransient<IManifestService, ManifestService>((provider) => new ManifestService(Configuration));
            services.AddTransient<IMovementService, MovementService>((provider) => new MovementService(Configuration, new DashboardService(Configuration), CacheService));
            services.AddTransient<IUpdateEventService, UpdateEventService>((provider) => new UpdateEventService(Configuration));
            services.AddTransient<IVisitorService, VisitorService>((provider) => new VisitorService(Configuration));
            services.AddTransient<IUpdatePhotoService, UpdatePhotoService>((provider) => new UpdatePhotoService(Configuration, CacheService));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Gangway Mobile Services", Version = "v1" });
                c.OperationFilter<AccessHeaderFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Gangway Middleware Service V1");
            });

            app.UseMiddleware(typeof(TimedOperationMiddleware));

            app.UseHttpsRedirection();

            // global exception handler
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvc();
        }
    }
}
