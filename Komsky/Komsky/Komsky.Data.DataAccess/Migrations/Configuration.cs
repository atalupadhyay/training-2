using Komsky.Data.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
namespace Komsky.Data.DataAccess.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<Komsky.Data.DataAccess.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

protected override void Seed(Komsky.Data.DataAccess.ApplicationDbContext context)
{
    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

    //seed roles
    var rolesNames = new List<string> { "Admin", "Agent", "Customer" };
    foreach (var roleName in rolesNames)
    {
        if (!roleManager.RoleExists(roleName))
        {
            var roleresult = roleManager.Create(new IdentityRole(roleName));
        }
    }
    //seed user
    string userName = "admin@komsky.com";
    string password = "Pa$$w0rd";
    var user = new ApplicationUser();
    user.UserName = userName;
    user.Email = userName;
    var adminResult = userManager.Create(user, password);
    if (adminResult.Succeeded)
    {
        var result = userManager.AddToRole(user.Id, rolesNames[0]);
    }
    base.Seed(context);
}
    }
}
