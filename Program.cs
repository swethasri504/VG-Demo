namespace Carnival.eGangway.Mobile.Service
{
    using System;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Carnival.eGangway.Mobile.Service.Repository;
    using Microsoft.Extensions.DependencyInjection;
    using Carnival.eGangway.Mobile.Service.Instrumentation;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using Serilog;

    public class Program
    {

        private static IConfiguration Configuration;

        public static void Main(string[] args)
        {

            Configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("serilogsetting.json", optional: true, reloadOnChange: true)
                               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                               .Build();

            // NLog: setup the logger first to catch all errors
            //var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            // Serilog: setup the logger first to catch all errors
            var logger = SeriLogManager.ConfigureSeriLog(Configuration);
            

            try
            {
                logger.Information("Starting Gangway Middleware Host...");                               
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {  
                logger.Error("Stoped Gangway Middleware Host, Exception occurred: ", ex);              
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                // NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(Configuration)
            .ConfigureServices(service => {
                service.AddSingleton<ILoginCounter, LoginCounterService>();
                //service.AddSingleton<ICacheService, CacheService>();
                service.AddSingleton<ICacheService, CacheDBService>((provider)=>new CacheDBService(Configuration));
            })
            .UseStartup<Startup>()
            .UseSerilog();
            //    .ConfigureLogging(logging =>
            //    {
            //        logging.ClearProviders();
            //        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            //    })
            //.UseNLog();
    }
}
