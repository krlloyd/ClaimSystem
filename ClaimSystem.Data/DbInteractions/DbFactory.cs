namespace ClaimSystem.Data.DbInteractions
{
    #region

    using System.Data.Entity;
    using ClaimSystem.Core;

    #endregion

    public class DbFactory : Disposable, IDbFactory
    {
        private DataContext _dataContext;

        public DbFactory()
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DataContext GetDataContext()
        {
            return _dataContext ?? (_dataContext = new DataContext());
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}