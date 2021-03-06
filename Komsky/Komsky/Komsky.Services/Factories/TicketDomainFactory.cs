﻿using Komsky.Data.Entities;
using Komsky.Domain.Models;

namespace Komsky.Services.Factories
{
    public static class TicketDomainFactory
    {
        public static TicketDomain Create(Ticket ticket)
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
                ProductId = ticket.ProductId,
                Product = ticket.Product,
                TicketState = ticket.TicketState,
                TicketPriority = ticket.TicketPriority
            };
        }

        public static TicketDomain CreateTicketDomain(this Ticket ticket)
        {
            return Create(ticket);
        }
    }
}
