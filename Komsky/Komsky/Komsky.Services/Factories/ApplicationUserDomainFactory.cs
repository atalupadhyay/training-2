using Komsky.Data.Entities;
using Komsky.Domain.Models.Identity;

namespace Komsky.Services.Factories
{
public static class ApplicationUserDomainFactory
{
    public static ApplicationUserDomain Create(ApplicationUser applicationUser)
    {
        return new ApplicationUserDomain
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

    public static ApplicationUserDomain CreateApplicationUserDomain(this ApplicationUser applicationUser)
    {
        return Create(applicationUser);
    }
}
}
