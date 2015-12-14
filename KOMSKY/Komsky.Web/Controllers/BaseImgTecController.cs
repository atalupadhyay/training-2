using System.Web.Mvc;
using Komsky.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Komsky.Web.Controllers
{
    public partial class BaseKomskyController : Controller
    {
        protected readonly ApplicationDbContext Context;
        protected readonly UserManager<ApplicationUser> UserManager;
        public BaseKomskyController()
        {
            Context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
        }

        public BaseKomskyController(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            Context = context;
            UserManager = manager;
        }
    }
}