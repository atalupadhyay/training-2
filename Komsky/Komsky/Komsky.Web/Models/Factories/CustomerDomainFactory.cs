using Komsky.Domain.Models;

namespace Komsky.Web.Models.Factories
{
    public static class CustomerDomainFactory
    {
        public static CustomerDomain Create(CustomerViewModel customerViewModel)
        {
            return new CustomerDomain { Id = customerViewModel.Id, Name = customerViewModel.Name };
        }

        public static CustomerDomain CreateCustomerDomain(this CustomerViewModel customerViewModel)
        {
            return Create(customerViewModel);
        }
    }
}