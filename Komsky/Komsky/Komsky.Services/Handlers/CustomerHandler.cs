using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komsky.Domain.Models;

namespace Komsky.Services.Handlers
{
    public class CustomerHandler : BaseHandler<CustomerDomain>
    {
        public override IEnumerable<CustomerDomain> GetAll()
        {
            return DataFacade.ApplicationUsers.GetAll().Select(x=>new CustomerDomain
            {
                Id = x.Id,
                Name = x.
            });
        }

        public override CustomerDomain GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override void Add(CustomerDomain domainObject)
        {
            throw new NotImplementedException();
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
