namespace ClaimSystem.Data.Repository
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ClaimSystem.Core.Models;
    using ClaimSystem.Core.Repositories;
    using ClaimSystem.Data.DbInteractions;

    #endregion

    public class InternalClaimRepository : EFRepositoryBase<InternalClaim>, IInternalClaimRepository
    {
        public InternalClaimRepository(IDbFactory databaseFactory) : base(databaseFactory)
        {
        }


        public new IEnumerable<InternalClaim> GetAll()
        {
            return EagerLoadedEntities();
        }

        public InternalClaim GetById(Guid id)
        {
            return EagerLoadedEntities().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<InternalClaim> GetByClientId(Guid clientId)
        {
            return EagerLoadedEntities().Where(x => x.Client.Id == clientId);
        }

        /// <summary>
        /// This function is used to eagerly load all the entities which means all
        /// the child objects will be loaded. i.e PolicyHolder, Client, Addresses,
        /// Employers ect.
        /// </summary>
        /// <returns>Loaded Enumerable of InternalClaims</returns>
        private IEnumerable<InternalClaim> EagerLoadedEntities()
        {
            // By retrieving the child values we force entity framework to 
            // join and load the related entites.
            var eagerEntities = Entities.Select(claim => new
                {
                    claim,
                    client = claim.Client,
                    policyHolder = claim.PolicyHolder,
                    policyHolderAdx = claim.PolicyHolder.Address,
                    policyHolderEmp = claim.PolicyHolder.Employer,
                    policyHolderEmpAdx = claim.PolicyHolder.Employer.Address,
                    patient = claim.Patient,
                    patientAdx = claim.Patient.Address,
                    patientEmp = claim.Patient.Employer,
                    patientEmpAdx = claim.Patient.Employer.Address,
                    extrinsics = claim.Extrinsics
                });

            return eagerEntities.AsEnumerable().Select(i => i.claim);
        }
    }
}