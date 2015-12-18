using Komsky.Data.Entities;
using Komsky.Domain.Models;

namespace Komsky.Domain.Factories
{
    public static class ProductDomainFactory
    {
        public static ProductDomain Create(Product product)
        {
            return new ProductDomain
            {
                Id = product.Id,
                Name = product.Name,
                ReleaseDate = product.ReleaseDate,
                Type = product.Type,
                CustomerId = product.CustomerId,
                Customer = product.Customer==null ? null : product.Customer.CreateCustomerDomain()
            };
        }

        public static ProductDomain CreateProductDomain(this Product product)
        {
            return Create(product);
        }
    }
}
