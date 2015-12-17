using Komsky.Domain.Models;

namespace Komsky.Web.Models.Factories
{
    public static class ProductDomainFactory
    {
        public static ProductDomain Create(ProductViewModel productViewModel)
        {
            return new ProductDomain
            {
                Customer = productViewModel.Customer.CreateCustomerDomain(),
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                ReleaseDate = productViewModel.ReleaseDate,
                Type = productViewModel.Type
            };
        }

        public static ProductDomain CreateProductDomain(this ProductViewModel productViewModel)
        {
            return Create(productViewModel);
        }
    }
}