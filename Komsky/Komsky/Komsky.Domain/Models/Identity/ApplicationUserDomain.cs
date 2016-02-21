using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Komsky.Domain.Models.Identity
{
    public class ApplicationUserDomain : IdentityUser
    {
        public int? CustomerId { get; set; }
        public CustomerDomain Customer { get; set; }
    }
}
