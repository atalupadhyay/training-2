using Komsky.Domain.Models;

namespace Komsky.Web.Models.Factories
{
    public static class TicketDomainFactory
    {
        public static TicketDomain Create(TicketViewModel ticket)
        {
            return new TicketDomain
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                AgentReply = ticket.AgentReply,
                AssignedAgent = ticket.AssignedAgent,
                Owner = ticket.Owner,
                OwnerId = ticket.OwnerId,
                AssignedAgentId = ticket.AssignedAgentId,
                TicketState = ticket.TicketState,
                TicketPriority = ticket.TicketPriority,
                ProductId = ticket.ProductId,
                Product = ticket.Product
            };
        }

        public static TicketDomain CreateTicketDomain(this TicketViewModel ticket)
        {
            return Create(ticket);
        }
    }
}
