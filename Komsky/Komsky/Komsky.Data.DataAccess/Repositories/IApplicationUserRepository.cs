using System.Threading.Tasks;
using Komsky.Data.Entities;

namespace Komsky.Data.DataAccess.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetByEmail(string email);
        Task<ApplicationUser> FindByIdAsync(string id);
        Task<ApplicationUser> FindByNameAsync(string name);
    }
}
