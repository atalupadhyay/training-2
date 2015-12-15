using Komsky.Data.Entities;

namespace Komsky.Data.DataAccess.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetByEmail(string email);
    }
}
