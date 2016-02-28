namespace Komsky.Data.DataAccess.Migrations
{
    using Komsky.Data.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Komsky.Data.DataAccess.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Komsky.Data.DataAccess.ApplicationDbContext context)
        {
            RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>();
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

            if (!(context.Roles.Any(u => u.Name == "Admin")))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!(context.Roles.Any(u => u.Name == "Agent")))
            {
                roleManager.Create(new IdentityRole { Name = "Agent" });
            }
            if (!(context.Roles.Any(u => u.Name == "User")))
            {
                roleManager.Create(new IdentityRole { Name = "User" });
            }


            if (!(context.Users.Any(u => u.UserName == "admin@komsky.com")))
            {
                var userToInsert = new ApplicationUser { UserName = "admin@komsky.com", Email = "admin@komsky.com", PhoneNumber = "07456789456" };
                var result = userManager.Create(userToInsert, "Pa$$w0rd");
                if (!result.Errors.Any())
                {
                    userManager.AddToRole(userToInsert.Id, "Admin");
                }
            }

            if (!(context.Users.Any(u => u.UserName == "agent@komsky.com")))
            {
                var userToInsert = new ApplicationUser { UserName = "agent@komsky.com", Email = "agent@komsky.com", PhoneNumber = "07456789456" };
                var result = userManager.Create(userToInsert, "Pa$$w0rd");
                if (!result.Errors.Any())
                {
                    userManager.AddToRole(userToInsert.Id, "Agent");
                }
            }
        }
    }
}
