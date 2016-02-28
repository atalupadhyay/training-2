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
    public class UserStore : IUserStore<ApplicationUserDomain>, IUserEmailStore<ApplicationUserDomain>, IUserLockoutStore<ApplicationUserDomain,string>
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

        public Task SetEmailAsync(ApplicationUserDomain user, string email)
        {
            var usr = _dataFacade.ApplicationUsers.GetById(user.Id);
            usr.Email = email;
            _dataFacade.ApplicationUsers.Update(usr);
            return _dataFacade.CommitAsync();
        }

        public Task<string> GetEmailAsync(ApplicationUserDomain user)
        {
            return Task.FromResult(_dataFacade.ApplicationUsers.GetById(user.Id).Email);
        }

        public Task<bool> GetEmailConfirmedAsync(ApplicationUserDomain user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(ApplicationUserDomain user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDomain> FindByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUserDomain user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(ApplicationUserDomain user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(ApplicationUserDomain user)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(ApplicationUserDomain user)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(ApplicationUserDomain user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(ApplicationUserDomain user)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(ApplicationUserDomain user, bool enabled)
        {
            throw new NotImplementedException();
        }
    }
}
