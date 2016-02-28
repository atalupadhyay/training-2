using AutoMapper;
using Komsky.Data.Entities;
using Komsky.Domain.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Komsky.Services.Factories
{
    public static class ApplicationUserFactory
    {
        public static ApplicationUser Create(ApplicationUserDomain applicationUserDomain)
        {
            return Mapper.DynamicMap<ApplicationUser>(applicationUserDomain);
        }

        public static ApplicationUser CreateApplicationUser(this ApplicationUserDomain applicationUser)
        {
            return Create(applicationUser);
        }

    }
}
