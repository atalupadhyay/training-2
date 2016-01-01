using System;
using Microsoft.AspNet.Identity;

namespace Komsky.Domain.Models.Identity
{
    public class ApplicationUserDomain : IUser<string>, IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public String Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public String PasswordHash { get; set; }
        public String SecurityStamp { get; set; }
        public String PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public int AccessFailedCount { get; set; }

        public int? CustomerId { get; set; }
        public CustomerDomain Customer { get; set; }
    }
}
