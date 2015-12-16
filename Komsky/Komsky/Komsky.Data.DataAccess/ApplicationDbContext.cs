﻿using System.Data.Entity;
using Komsky.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Komsky.Data.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}