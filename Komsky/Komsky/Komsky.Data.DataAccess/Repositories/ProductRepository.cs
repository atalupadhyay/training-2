using System.Data.Entity;
using Komsky.Data.Entities;

namespace Komsky.Data.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
