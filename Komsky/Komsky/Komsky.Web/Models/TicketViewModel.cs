using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Komsky.Data.Entities;
using Komsky.Enums;

namespace Komsky.Web.Models
{
    public class TicketViewModel
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        [StringLength(1000,MinimumLength = 10)]
        public String Description { get; set; }
        [DisplayName("Ticket Priority")]
        public TicketPriority TicketPriority { get; set; }
        [DisplayName("Ticket State")]
        public TicketState TicketState { get; set; }
        [DisplayName("Agent's reply")]
        public String AgentReply { get; set; }
        [DisplayName("Owner's name")]
        public String OwnerName { get; set; }
        public ApplicationUser Owner { get; set; }
        [DisplayName("Assigned agent's name")]
        public String AssignedAgentName { get; set; }
        public ApplicationUser AssignedAgent { get; set; }
    }
}