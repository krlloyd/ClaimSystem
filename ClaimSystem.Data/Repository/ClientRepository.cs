namespace ClaimSystem.Data.Repository
{
    #region

    using System.Linq;
    using ClaimSystem.Core.Models;
    using ClaimSystem.Core.Repositories;
    using ClaimSystem.Data.DbInteractions;

    #endregion

    public class ClientRepository : EFRepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(IDbFactory databaseFactory) : base(databaseFactory)
        {
        }

        public Client GetByClientName(string clientName)
        {
            return Entities.FirstOrDefault(x => x.Name == clientName);
        }
    }
}