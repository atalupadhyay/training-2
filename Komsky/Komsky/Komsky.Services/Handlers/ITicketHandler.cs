using System.Collections;
using System.Collections.Generic;
using Komsky.Domain.Models;

namespace Komsky.Services.Handlers
{
    public interface ITicketHandler : IBaseHandler<TicketDomain>
    {
        IEnumerable<TicketDomain> SearchTickets(string searchterm);
        IEnumerable<TicketDomain> TicketsForProduct(int productId);
    }
}
