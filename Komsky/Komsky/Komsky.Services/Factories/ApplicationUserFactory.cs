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
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                EmailConfirmed = applicationUser.EmailConfirmed,
                PasswordHash = applicationUser.PasswordHash,
                SecurityStamp = applicationUser.SecurityStamp,
                PhoneNumber = applicationUser.PhoneNumber,
                PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed,
                TwoFactorEnabled = applicationUser.TwoFactorEnabled,
                LockoutEnabled = applicationUser.LockoutEnabled,
                LockoutEndDateUtc = applicationUser.LockoutEndDateUtc,
                AccessFailedCount = applicationUser.AccessFailedCount,
                UserName = applicationUser.UserName,
                CustomerId = applicationUser.CustomerId
            };
        }

        public static ApplicationUser CreateApplicationUser(this ApplicationUserDomain applicationUser)
        {
            return Create(applicationUser);
        }

    }
}
