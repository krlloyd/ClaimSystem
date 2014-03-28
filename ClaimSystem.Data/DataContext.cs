namespace ClaimSystem.Data
{
    #region

    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Reflection;
    using ClaimSystem.Data.DbInteractions;

    #endregion

    public class DataContext : DbContext, IDbContext
    {
        public DataContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = true;
            Configuration.LazyLoadingEnabled = false;

        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                          .Where(type => !String.IsNullOrEmpty(type.Namespace))
                                          .Where(
                                              type =>
                                              type.BaseType != null && type.BaseType.IsGenericType &&
                                              type.BaseType.GetGenericTypeDefinition() ==
                                              typeof (EntityTypeConfiguration<>));


            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic) configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}