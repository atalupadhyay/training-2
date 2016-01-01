﻿using Komsky.Data.Entities;
using Komsky.Domain.Models.Identity;

namespace Komsky.Services.Factories
{
public static class ApplicationUserDomainFactory
{
    public static ApplicationUserDomain Create(ApplicationUser applicationUser)
    {
        return new ApplicationUserDomain
        {
            UserName = applicationUser.UserName,
            Id = applicationUser.Id,
            Email = applicationUser.Email,
            PasswordHash = applicationUser.PasswordHash,
            PhoneNumber = applicationUser.PhoneNumber
        };
    }

    public static ApplicationUserDomain CreateApplicationUserDomain(this ApplicationUser applicationUser)
    {
        return Create(applicationUser);
    }
}
}
