namespace ClaimSystem.Core.Repositories
{
    #region

    using System;

    #endregion

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}