namespace Carnival.eGangway.Mobile.Service
{
    public static class Routes
    {
        /// <summary>
        /// Service status routes.
        /// </summary>
        public const string ServiceStatus = "status";

        /// <summary>
        /// Login routes.
        /// </summary>
        public const string Login = "auth/login";

        /// <summary>
        /// Admin login routes.
        /// </summary>
        public const string AdminLogin = "auth/login/admin";

        /// <summary>
        /// Admin reset routes.
        /// </summary>
        public const string AdminReset="auth/reset";

        /// <summary>
        /// Ships routes.
        /// </summary>
        public const string Ships = "ships";

        /// <summary>
        /// Dashboard routes.
        /// </summary>
        public const string Dashboard = "dashboard";

        /// <summary>
        /// Person routes.
        /// </summary>
        public const string Person = "person/{voyno}";

        /// <summary>
        /// Specific ship routes.
        /// </summary>
        public const string Ship = "specificship";

        /// <summary>
        /// Manifest routes.
        /// </summary>
        public const string Manifest = "manifest";

        /// <summary>
        /// Update movement routes.
        /// </summary>
        public const string UpdateMovement = "updatemovement";

        /// <summary>
        /// Update movement routes.
        /// </summary>
        public const string UpdateMovementAndEvent = "updatemovementandevent";

        /// <summary>
        /// Update event routes.
        /// </summary>
        public const string UpdateEvent = "updateevent";

        /// <summary>
        /// Update Movementcache routes.
        /// </summary>
        public const string UpdateCache = "updatecache";

        /// <summary>
        /// Update photoCache routes.
        /// </summary>
        public const string UpdatePhotoCache = "updatePhotocache";

        /// <summary>
        /// Add Visitor routes.
        /// </summary>
        public const string AddVisitor = "AddVisitor";

        /// <summary>
        /// Update Photo routes.
        /// </summary>
        public const string UpdatePhoto = "updatePhoto";


        /// <summary>
        /// Instrumentation.
        /// </summary>
        public const string Instrumentation = "instrumentation";


    }
}
