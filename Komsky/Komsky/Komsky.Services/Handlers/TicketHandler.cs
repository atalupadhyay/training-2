using System.Collections.Generic;
using System.Linq;
using Komsky.Domain.Models;
using Komsky.Services.Factories;

namespace Komsky.Services.Handlers
{
    public class TicketHandler : BaseHandler<TicketDomain>
    {
        public override IEnumerable<TicketDomain> GetAll()
        {
            return DataFacade.Tickets.GetAll().Select(TicketDomainFactory.Create);
        }

        public override TicketDomain GetById(int id)
        {
            return DataFacade.Tickets.GetById(id).CreateTicketDomain();
        }

        public override void Add(TicketDomain domainObject)
        {
            DataFacade.Tickets.Add(domainObject.CreateTicket());
        }

        public override void Update(TicketDomain domainObject)
        {
            DataFacade.Tickets.Update(domainObject.CreateTicket());
        }

        public override void Delete(TicketDomain domainObject)
        {
            Delete(domainObject.Id);
        }

        public override void Delete(int domainObjectId)
        {
            DataFacade.Tickets.Delete(domainObjectId);
        }
    }
}
