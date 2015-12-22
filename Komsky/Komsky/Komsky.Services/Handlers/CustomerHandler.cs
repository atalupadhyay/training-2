using System.Collections.Generic;
using System.Linq;
using Komsky.Domain.Models;
using Komsky.Services.Factories;

namespace Komsky.Services.Handlers
{
    public class CustomerHandler : BaseHandler<CustomerDomain>
    {
        public override IEnumerable<CustomerDomain> GetAll()
        {
            return DataFacade.Customers.GetAll().Select(CustomerDomainFactory.Create);
        }

        public override CustomerDomain GetById(int id)
        {
            return DataFacade.Customers.GetById(id).CreateCustomerDomain();
        }

        public override void Add(CustomerDomain domainObject)
        {
            DataFacade.Customers.Add(domainObject.CreateCustomer());
        }

        public override void Update(CustomerDomain domainObject)
        {
            DataFacade.Customers.Update(domainObject.CreateCustomer());
        }

        public override void Delete(CustomerDomain domainObject)
        {
            Delete(domainObject.Id);
        }

        public override void Delete(int domainObjectId)
        {
            DataFacade.Customers.Delete(domainObjectId);
        }
    }
}
