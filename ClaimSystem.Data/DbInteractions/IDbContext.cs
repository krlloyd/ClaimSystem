namespace ClaimSystem.Data.DbInteractions
{
    #region

    using System.Data.Entity;

    #endregion

    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Commit();
        void Dispose();
    }
}