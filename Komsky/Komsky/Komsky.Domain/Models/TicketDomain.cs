using System;
using Komsky.Domain.Models.Identity;
using Komsky.Enums;

namespace Komsky.Domain.Models
{
    public class TicketDomain
    {
        public Int32 Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public TicketPriority TicketPriority { get; set; }
        public TicketState TicketState { get; set; }
        public String AgentReply { get; set; }
        public int? ProductId { get; set; }
        public ProductDomain Product { get; set; }
        public String OwnerId { get; set; }
        public ApplicationUserDomain Owner { get; set; }
        public String AssignedAgentId { get; set; }
        public ApplicationUserDomain AssignedAgent { get; set; }
    }
}
