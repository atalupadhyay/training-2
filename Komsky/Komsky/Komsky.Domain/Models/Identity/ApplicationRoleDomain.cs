using Microsoft.AspNet.Identity;

namespace Komsky.Domain.Models.Identity
{
    public class ApplicationRoleDomain : IRole<string>
    {
        public string Id { get; private set; }
        public string Name { get; set; }
    }
}
