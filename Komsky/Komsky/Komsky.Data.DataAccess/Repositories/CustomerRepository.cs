using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
