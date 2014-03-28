namespace ClaimSystem.Core.Repositories
{
    #region

    using ClaimSystem.Core.Models;

    #endregion

    public interface IClientRepository : IRepository<Client>
    {
        Client GetByClientName(string clientName);
    }
}