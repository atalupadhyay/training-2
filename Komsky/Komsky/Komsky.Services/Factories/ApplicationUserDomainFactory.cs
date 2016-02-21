using AutoMapper;
using Komsky.Data.Entities;
using Komsky.Domain.Models.Identity;

namespace Komsky.Services.Factories
{
public static class ApplicationUserDomainFactory
{
    public static ApplicationUserDomain Create(ApplicationUser applicationUser)
    {
        return Mapper.DynamicMap<ApplicationUserDomain>(applicationUser);
    }

    public static ApplicationUserDomain CreateApplicationUserDomain(this ApplicationUser applicationUser)
    {
        return Create(applicationUser);
    }
}
}
