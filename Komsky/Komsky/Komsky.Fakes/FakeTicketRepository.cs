using System;
using System.Collections.Generic;
using System.Linq;
using Komsky.Data.DataAccess.Repositories;
using Komsky.Data.Entities;
using Komsky.Enums;

namespace Komsky.Fakes
{
    public class FakeTicketRepository : ITicketRepository
    {
        public IQueryable<Ticket> GetAll()
        {
            return GetFakeTickets();
        }

        private IQueryable<Ticket> GetFakeTickets()
        {
            List<Ticket> fakeTickets = new List<Ticket>();
            for (int i = 0; i < 5; i++)
            {
                fakeTickets.Add(GetFakeTicket());
            }
            return fakeTickets.AsQueryable();
        }

        public static Ticket GetFakeTicket(int id)
        {
            var fakeUser = FakeApplicationUserRepository.GetFakeUser();
            var fakeOwner = FakeApplicationUserRepository.GetFakeUser();
            var fakeProduct = FakeProductRepository.GetFakeProduct();
            return new Ticket
            {
                AgentReply = "Fake reply",
                AssignedAgent = fakeUser,
                AssignedAgentId = fakeUser.Id,
                Description = "Fake description",
                Id = id,
                Owner = fakeOwner,
                OwnerId = fakeOwner.Id,
                Product = fakeProduct,
                ProductId = fakeProduct.Id,
                TicketPriority = TicketPriority.Normal,
                TicketState = TicketState.Assigned,
                Title = "Fake ticket"
            };
        }
        public static Ticket GetFakeTicket()
        {
            return GetFakeTicket(1);
        }

        public Ticket GetById(int id)
        {
            return GetFakeTicket();
        }

        public Ticket GetById(Guid id)
        {
            return GetFakeTicket();
        }

        public Ticket GetById(string id)
        {
            return GetFakeTicket();
        }

        public void Add(Ticket entity)
        {
            
        }

        public void Update(Ticket entity)
        {
            
        }

        public void Delete(Ticket entity)
        {
           
        }

        public void Delete(int id)
        {
           
        }

        public void Delete(Guid id)
        {
            
        }

        public void Delete(string id)
        {
           
        }
    }
}
