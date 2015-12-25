﻿using System;
using Komsky.Data.Entities;
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
        public String OwnerName { get; set; }
        public ApplicationUser Owner { get; set; }
        public String AssignedAgentName { get; set; }
        public ApplicationUser AssignedAgent { get; set; }
    }
}
