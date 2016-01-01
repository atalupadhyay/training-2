using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        public Task<ApplicationUser> FindByIdAsync(string id)
        {
            return Task.FromResult(GetById(id));
        }

        public Task<ApplicationUser> FindByNameAsync(string name)
        {
            return Task.FromResult(GetAll().First(x => x.UserName == name));
        }
    }
}
