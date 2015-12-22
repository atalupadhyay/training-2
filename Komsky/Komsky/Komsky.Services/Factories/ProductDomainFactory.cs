using Komsky.Data.Entities;
using Komsky.Domain.Models;

namespace Komsky.Services.Factories
{
public static class ProductDomainFactory
{
    public static ProductDomain Create(Product product, CustomerDomain customerDomain)
    {
        ProductDomain productDomain = new ProductDomain
        {
            Id = product.Id,
            Name = product.Name,
            ReleaseDate = product.ReleaseDate,
            Type = product.Type,
            CustomerId = product.CustomerId
        };
        if (customerDomain != null)
        {
            productDomain.Customer = customerDomain;
        }
        else
        {
            productDomain.Customer = product.Customer == null ? null : product.Customer.CreateCustomerDomain();
        }
        return productDomain;
    }

        public static ProductDomain Create(Product product)
        {
            return Create(product, null);
        }

        public static ProductDomain CreateProductDomain(this Product product, CustomerDomain customerDomain = null)
        {
            return Create(product, customerDomain);
        }
    }
}
