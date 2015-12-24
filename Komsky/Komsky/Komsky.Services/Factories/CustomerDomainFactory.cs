using System.Collections.Generic;
using System.Linq;
using Komsky.Data.Entities;
using Komsky.Domain.Models;

namespace Komsky.Services.Factories
{
    public static class CustomerDomainFactory
    {
        public static CustomerDomain Create(Customer customer)
        {
            CustomerDomain customerDomain = new CustomerDomain
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                PIN = customer.PIN
            };

            if (customer.Products != null && customer.Products.Any())
            {
                var productList = new List<ProductDomain>();
                foreach (var product in customer.Products)
                {
                    productList.Add(product.CreateProductDomain(customerDomain));
                }
                customerDomain.Products = productList;
            }
            return customerDomain;
        }

        public static CustomerDomain CreateCustomerDomain(this Customer customer)
        {
            return Create(customer);
        }
    }
}
