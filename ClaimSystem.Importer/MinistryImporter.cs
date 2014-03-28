using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimSystem.Importer
{
    using ClaimSystem.Core.Models;
    using ClaimSystem.Core.Repositories;
    using ClaimSystem.Importer.Converters.MinistryHealth;

    public interface IMinistryImporter
    {
        void Import(IMinistryHealthConverter ministryHealthConverter, string feedPath);
    }

    public class MinistryImporter : IMinistryImporter
    {
        private readonly IInternalClaimRepository _claimRepository;
        private readonly IClientRepository _clientRepository;

        private readonly IUnitOfWork _uow;

        public MinistryImporter(IUnitOfWork uow, IInternalClaimRepository claimRepository, IClientRepository clientRepository)
        {
            _uow = uow;
            _claimRepository = claimRepository;
            _clientRepository = clientRepository;
            
        }

        public void Import(IMinistryHealthConverter ministryHealthConverter, string feedPath)
        {
            
            var convertedClaims = ministryHealthConverter.Process(feedPath,GetClient());

            foreach(var claim in convertedClaims)
                _claimRepository.Create(claim);

            _uow.Commit();
        }


        /// <summary>
        /// If exists return ministry client else create one and return.
        /// </summary>
        /// <returns>Ministry Client</returns>
        private Client GetClient()
        {
            var client = _clientRepository.GetByClientName("Ministry Health Care");

            if (client != null)
                return client;

            var newClient = new Client {Name = "Ministry Health Care"};
            _clientRepository.Create(newClient);
            
            _uow.Commit();

            return newClient;
        }
    }
}
