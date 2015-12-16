using System;
using System.Collections.Generic;
using System.Linq;
using Komsky.Data.Entities;
using Komsky.Domain.Models;

namespace Komsky.Services.Handlers
{
    public class CustomerHandler : BaseHandler<CustomerDomain>
    {
        public override IEnumerable<CustomerDomain> GetAll()
        {
            return DataFacade.Customers.GetAll().Select(x=>new CustomerDomain
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public override CustomerDomain GetById(int id)
        {
            var customer = DataFacade.Customers.GetById(id);
            return new CustomerDomain{Id = customer.Id, Name = customer.Name};
        }

        public override void Add(CustomerDomain domainObject)
        {
            DataFacade.Customers.Add(new Customer{Id = domainObject.Id, Name = domainObject.Name});
        }

        public override void Update(CustomerDomain domainObject)
        {
            throw new NotImplementedException();
        }

        public override void Delete(CustomerDomain domainObject)
        {
            throw new NotImplementedException();
        }

        public override void Delete(int domainObjectId)
        {
            throw new NotImplementedException();
        }
    }
}
