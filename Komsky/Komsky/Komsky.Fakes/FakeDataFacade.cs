using System.Threading.Tasks;
using Komsky.Data.DataAccess.Repositories;
using Komsky.Data.DataAccess.UnitOfWork;

namespace Komsky.Fakes
{
    public class FakeDataFacade : IDataFacade
    {
        public void Dispose() { }
        public void Commit() { }
        public Task CommitAsync()
        {
            return new Task(() => { });
        }

        public IApplicationUserRepository ApplicationUsers
        {
            get { return new FakeApplicationUserRepository(); }
        }
        public ICustomerRepository Customers
        {
            get { return new FakeCustomerRepository(); }
        }

        public IProductRepository Products
        {
            get { return new FakeProductRepository();}
        }

        public ITicketRepository Tickets
        {
            get { return new FakeTicketRepository();}
        }
    }


}

