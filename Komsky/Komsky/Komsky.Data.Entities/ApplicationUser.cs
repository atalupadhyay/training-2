using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Komsky.Data.Entities
{
    public class ApplicationUser : IUser<string>
    {
        public Customer Customer { get; set; }

        public string Id { get; set; }
        public string UserName { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public String PhoneNumber { get; set; }
    }

}