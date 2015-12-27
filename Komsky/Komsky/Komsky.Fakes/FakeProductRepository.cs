using System;
using System.Collections.Generic;
using System.Linq;
using Komsky.Data.DataAccess.Repositories;
using Komsky.Data.Entities;
using Komsky.Enums;

namespace Komsky.Fakes
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> GetAll()
        {
            return GetFakeProducts();
        }

        private IQueryable<Product> GetFakeProducts()
        {
            List<Product> fakeProducts = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                fakeProducts.Add(GetFakeProduct());
            }
            return fakeProducts.AsQueryable();
        }

        public static Product GetFakeProduct(int id)
        {
            var fakeCustomer = FakeCustomerRepository.GetFakeCustomer();
            return new Product
            {
                Customer = fakeCustomer,
                CustomerId = fakeCustomer.Id,
                Id = id,
                Name = "Fake product",
                ReleaseDate = DateTime.Now,
                Type = ProductType.Other
            };
        }

        public static Product GetFakeProduct()
        {
            return GetFakeProduct(1);
        }

        public Product GetById(int id)
        {
            return GetFakeProduct();
        }

        public Product GetById(Guid id)
        {
            return GetFakeProduct();
        }

        public Product GetById(string id)
        {
            return GetFakeProduct();
        }

        public void Add(Product entity)
        {
           
        }

        public void Update(Product entity)
        {
           
        }

        public void Delete(Product entity)
        {
            
        }

        public void Delete(int id)
        {
            
        }

        public void Delete(Guid id)
        {
            
        }

        public void Delete(string id)
        {
            
        }
    }
}
