namespace ClaimSystem.Core.Repositories
{
    #region

    using System;
    using System.Collections.Generic;
    using ClaimSystem.Core.Models;

    #endregion

    public interface IInternalClaimRepository : IRepository<InternalClaim>
    {
        InternalClaim GetById(Guid id);
        IEnumerable<InternalClaim> GetByClientId(Guid clientId);
    }
}