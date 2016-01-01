using Komsky.Data.Entities;
using Komsky.Domain.Models.Identity;

namespace Komsky.Services.Factories
{
    public static class ApplicationUserFactory
    {
        public static ApplicationUser Create(ApplicationUserDomain applicationUser)
        {
            return new ApplicationUser
            {
                UserName = applicationUser.UserName,
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                PasswordHash = applicationUser.PasswordHash,
                PhoneNumber = applicationUser.PhoneNumber
            };
        }

        public static ApplicationUser CreateApplicationUser(this ApplicationUserDomain applicationUser)
        {
            return Create(applicationUser);
        }

    }
}
