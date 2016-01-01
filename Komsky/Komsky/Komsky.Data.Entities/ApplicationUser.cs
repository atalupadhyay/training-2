using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Komsky.Data.Entities
{
    public class ApplicationUser : IUser<string>
    {
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

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
    }

}