using System;
using Microsoft.AspNet.Identity;

namespace Komsky.Domain.Models.Identity
{
    public class ApplicationUserDomain : IUser<string>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public String PhoneNumber { get; set; }
    }
}
