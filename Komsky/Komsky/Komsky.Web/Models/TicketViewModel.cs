using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Owner's ID")]
        public String OwnerId { get; set; }
        //TODO: public ApplicationUser Owner { get; set; }
        [DisplayName("Assigned agent's ID")]
        public String AssignedAgentId { get; set; }
        //TODO: public ApplicationUser AssignedAgent { get; set; }
        [DisplayName("Product ID")]
        public int? ProductId { get; set; }
        public ProductViewModel Product { get; set; }

        //---- ViewModel specific ----//
        public IEnumerable<ProductViewModel> AllProducts { get; set; }
    }
}