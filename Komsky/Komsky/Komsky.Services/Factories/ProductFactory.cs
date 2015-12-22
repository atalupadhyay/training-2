using Komsky.Data.Entities;
using Komsky.Domain.Models;

namespace Komsky.Services.Factories
{
    public static class ProductFactory
    {
        public static Product Create(ProductDomain productDomain)
        {
            return new Product
            {
                Id = productDomain.Id,
                Customer = productDomain.Customer.CreateCustomer(),
                Name = productDomain.Name,
                ReleaseDate = productDomain.ReleaseDate,
                Type = productDomain.Type
            };
        }

        public static Product CreateProduct(this ProductDomain productDomain)
        {
            return Create(productDomain);
        }
    }
}
