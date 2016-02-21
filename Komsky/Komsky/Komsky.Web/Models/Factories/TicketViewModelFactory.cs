using Komsky.Domain.Models;

namespace Komsky.Web.Models.Factories
{
    public static class TicketViewModelFactory
    {
        public static TicketViewModel Create(TicketDomain ticketDomain)
        {
            return new TicketViewModel
            {
                Id = ticketDomain.Id,
                Title = ticketDomain.Title,
                Description = ticketDomain.Description,
                AgentReply = ticketDomain.AgentReply,
                AssignedAgent = ticketDomain.AssignedAgent,
                Owner = ticketDomain.Owner,
                OwnerId = ticketDomain.OwnerId,
                AssignedAgentId = ticketDomain.AssignedAgentId,
                TicketState = ticketDomain.TicketState,
                TicketPriority = ticketDomain.TicketPriority,
                ProductId = ticketDomain.ProductId,
                Product = ticketDomain.Product
            };
        }

        public static TicketViewModel CreateTicketViewModel(this TicketDomain ticketDomain)
        {
            return Create(ticketDomain);
        }
    }
}
