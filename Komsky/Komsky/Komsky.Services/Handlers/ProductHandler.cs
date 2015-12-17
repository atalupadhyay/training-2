using System.Collections.Generic;
using System.Linq;
using Komsky.Domain.Factories;
using Komsky.Domain.Models;

namespace Komsky.Services.Handlers
{
    public class ProductHandler : BaseHandler<ProductDomain>
    {
        public override IEnumerable<ProductDomain> GetAll()
        {
            return DataFacade.Products.GetAll().Select(ProductDomainFactory.Create);
        }

        public override ProductDomain GetById(int id)
        {
            return DataFacade.Products.GetById(id).CreateProductDomain();
        }

        public override void Add(ProductDomain domainObject)
        {
            DataFacade.Products.Add(domainObject.CreateProduct());
        }

        public override void Update(ProductDomain domainObject)
        {
            DataFacade.Products.Update(domainObject.CreateProduct());
        }

        public override void Delete(ProductDomain domainObject)
        {
            Delete(domainObject.Id);
        }

        public override void Delete(int domainObjectId)
        {
            DataFacade.Products.Delete(domainObjectId);
        }
    }
}
