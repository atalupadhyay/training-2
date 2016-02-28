using System;
using System.Collections.Generic;
using System.Linq;
using Komsky.Data.DataAccess.Repositories;
using Komsky.Data.Entities;

namespace Komsky.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public IQueryable<Customer> GetAll()
        {
            return GetFakeCustomers();
        }

        private IQueryable<Customer> GetFakeCustomers()
        {
            List<Customer> fakeCustomers = new List<Customer>();
            for (int i = 0; i < 5; i++)
            {
                fakeCustomers.Add(GetFakeCustomer());
            }
            return fakeCustomers.AsQueryable();
        }

        public Customer GetById(int id)
        {
            return GetFakeCustomer();
        }

        public static Customer GetFakeCustomer()
        {
            return new Customer
            {
                Email = "fake@customer.com",
                Id = 1,
                Name = "Fake customer",
                Phone = "0500-555-555",
                PIN = "1234"
            };
        }

        public Customer GetById(Guid id)
        {
            return GetFakeCustomer();
        }

        public Customer GetById(string id)
        {
            return GetFakeCustomer();
        }

        public void Add(Customer entity)
        {
        }

        public void Update(Customer entity)
        {
        }

        public void Delete(Customer entity)
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
