using System;
using System.Threading.Tasks;
using Komsky.Data.DataAccess.Repositories;

namespace Komsky.Data.DataAccess.UnitOfWork
{
    public interface IDataFacade : IDisposable
    {
        void Commit();
        Task CommitAsync();
        ApplicationUserRepository ApplicationUsers { get; }
        CustomerRepository Customers { get; }
        ProductRepository Products { get; }
    }
}
