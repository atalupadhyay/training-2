using Komsky.Data.Entities;
using Komsky.Domain.Models;

namespace Komsky.Services.Factories
{
    public static class TicketFactory
    {
        public static Ticket Create(TicketDomain ticketDomain)
        {
            return new Ticket
            {
                Id = ticketDomain.Id,
                Title = ticketDomain.Title,
                Description = ticketDomain.Description,
                AgentReply = ticketDomain.AgentReply,
                AssignedAgent = ticketDomain.AssignedAgent.CreateApplicationUser(),
                ProductId = ticketDomain.ProductId,
                Product = ticketDomain.Product.CreateProduct(),
                Owner = ticketDomain.Owner.CreateApplicationUser(),
                OwnerId = ticketDomain.OwnerId,
                AssignedAgentId = ticketDomain.AssignedAgentId,
                TicketState = ticketDomain.TicketState,
                TicketPriority = ticketDomain.TicketPriority
            };
        }

        public static Ticket CreateTicket(this TicketDomain ticketDomain)
        {
            return Create(ticketDomain);
        }
    }
}
