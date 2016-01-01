using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Komsky.Data.DataAccess.UnitOfWork;
using Komsky.Domain.Models.Identity;
using Komsky.Services.Factories;
using Microsoft.AspNet.Identity;

namespace Komsky.Services.Identity
{
    public class UserStore : IUserStore<ApplicationUserDomain>
    {
        private readonly IDataFacade _dataFacade;

        public UserStore(IDataFacade dataFacade)
        {
            _dataFacade = dataFacade;
        }

        public void Dispose()
        {
            _dataFacade.Dispose();
        }

        public Task CreateAsync(ApplicationUserDomain user)
        {
            _dataFacade.ApplicationUsers.Add(user.CreateApplicationUser());
            return _dataFacade.CommitAsync();
        }

        public Task UpdateAsync(ApplicationUserDomain user)
        {
            _dataFacade.ApplicationUsers.Update(user.CreateApplicationUser());
            return _dataFacade.CommitAsync();
        }

        public Task DeleteAsync(ApplicationUserDomain user)
        {
            _dataFacade.ApplicationUsers.Delete(user.Id);
            return _dataFacade.CommitAsync();
        }

        public Task<ApplicationUserDomain> FindByIdAsync(string userId)
        {
            return _dataFacade.ApplicationUsers
                .FindByIdAsync(userId)
                .ContinueWith(x => x.Result.CreateApplicationUserDomain());
        }

        public Task<ApplicationUserDomain> FindByNameAsync(string userName)
        {
            return _dataFacade.ApplicationUsers
                .FindByNameAsync(userName)
                .ContinueWith(x => x.Result.CreateApplicationUserDomain());
        }
    }
}
