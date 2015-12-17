using System.Data.Entity;
using Komsky.Data.Entities;

namespace Komsky.Data.DataAccess.Repositories
{
public class CustomerRepository :  GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(DbContext dbContext) : base(dbContext)
    {
    }
}
}
