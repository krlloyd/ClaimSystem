namespace ClaimSystem.Data.Repository
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using ClaimSystem.Core.Repositories;
    using ClaimSystem.Data.DbInteractions;

    #endregion

    /// <summary>
    /// The base class for entity Framework repository implementations
    /// </summary>
    public abstract class EFRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbSet<TEntity> _dbSet;
        private DataContext _context;

        protected EFRepositoryBase(IDbFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbSet = DataContext.Set<TEntity>();
        }

        protected IDbFactory DatabaseFactory { get; private set; }

        protected DataContext DataContext
        {
            get { return _context ?? (_context = DatabaseFactory.GetDataContext()); }
        }

        protected IDbSet<TEntity> Entities
        {
            get { return _dbSet; }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }

        public TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public void Create(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void Delete(object id)
        {
            var entityToDelete = Entities.Find(id);

            if (entityToDelete != null)
                Delete(entityToDelete);
        }

        #region DISPOSABLE

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposing) return;

            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        #endregion
        
    }
}