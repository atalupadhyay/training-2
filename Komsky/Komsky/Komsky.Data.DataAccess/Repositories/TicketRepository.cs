using System.Data.Entity;
using Komsky.Data.Entities;

namespace Komsky.Data.DataAccess.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
