namespace ClaimSystem.Sandbox
{
    #region

    using ClaimSystem.Core.Repositories;
    using ClaimSystem.Data.DbInteractions;
    using ClaimSystem.Data.Repository;
    using ClaimSystem.Importer;
    using ClaimSystem.Importer.Converters.Base;
    using ClaimSystem.Importer.Converters.MinistryHealth;
    using Microsoft.Practices.Unity;

    #endregion

    public static class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();

            return container;
        }

        /// <summary>
        /// This is where we register our implementations with the IoC container.
        /// </summary>
        /// <returns></returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // DB Bindings
            container.RegisterType<IDbFactory, DbFactory>(new PerThreadLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerThreadLifetimeManager());

            // REPOSITORY BINDINGS
            container.RegisterType<IClientRepository, ClientRepository>(new PerThreadLifetimeManager());
            container.RegisterType<IInternalClaimRepository, InternalClaimRepository>(new PerThreadLifetimeManager());

            // CONVERTERS
            container.RegisterType<IMinistryHealthConverter, MinistryHealthConverter>(new PerThreadLifetimeManager());

            // IMPORTERS
            container.RegisterType<IMinistryImporter, MinistryImporter>(new PerThreadLifetimeManager());

            return container;
        }
    }
}