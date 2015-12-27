using System;
using System.Threading.Tasks;
using Komsky.Data.DataAccess.Repositories;

namespace Komsky.Data.DataAccess.UnitOfWork
{
    public interface IDataFacade : IDisposable
    {
        void Commit();
        Task CommitAsync();
        IApplicationUserRepository ApplicationUsers { get; }
        ICustomerRepository Customers { get; }
        IProductRepository Products { get; }
        ITicketRepository Tickets { get; }
    }
}
