namespace ClaimSystem.Data.DbInteractions
{
    #region

    using ClaimSystem.Core;
    using ClaimSystem.Core.Repositories;

    #endregion

    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private readonly IDbFactory _databaseFactory;
        private DataContext _dataContext;

        public UnitOfWork(IDbFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        protected DataContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.GetDataContext()); }
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}