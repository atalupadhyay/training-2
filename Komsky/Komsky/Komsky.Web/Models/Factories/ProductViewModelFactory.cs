using Komsky.Domain.Models;

namespace Komsky.Web.Models.Factories
{
    public static class ProductViewModelFactory
    {
        public static ProductViewModel Create(ProductDomain productDomain)
        {
            return new ProductViewModel
            {
                Customer = productDomain.Customer.CreateCustomerViewModel(),
                Id = productDomain.Id,
                Name = productDomain.Name,
                ReleaseDate = productDomain.ReleaseDate,
                Type = productDomain.Type
            };

        }
        public static ProductViewModel CreateProductViewModel(this ProductDomain productDomain)
        {
            return Create(productDomain);
        }
    }
}