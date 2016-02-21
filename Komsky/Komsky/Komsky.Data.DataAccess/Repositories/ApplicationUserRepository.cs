using System.Data.Entity;
using System.Linq;
using Komsky.Data.Entities;

namespace Komsky.Data.DataAccess.Repositories
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public ApplicationUser GetByEmail(string email)
        {
            return GetAll().SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
        }
    }
}
