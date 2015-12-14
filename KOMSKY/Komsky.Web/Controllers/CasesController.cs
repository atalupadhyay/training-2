using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Komsky.Web.Models;
using Komsky.Web.Models.Enums;
using Microsoft.AspNet.Identity;

namespace Komsky.Web.Controllers
{
    [Authorize(Roles = "Customers, Agents, Admins")]
    public partial class CasesController : BaseKomskyController
    {
        public CasesController()
        {
        }

        public CasesController(ApplicationDbContext context, UserManager<ApplicationUser> manager) :base(context,manager){}

        public virtual async Task<ActionResult> Index()
        {
            if (User.IsInRole("Agents") || User.IsInRole("Admins"))
            {
                return View(Context.Cases.Include(x => x.Owner).Include(x => x.Agent).ToList());
            }
            else
            {
                //2) Customer users shall be able to view their own company's cases
                var userId = User.Identity.GetUserId();
                var currentUser = await UserManager.FindByIdAsync(userId);

                //find by async does not fills every property and don't have time to implement custom user store
                var currentCustomer = Context.Users.Include(x => x.Customer).Where(x => x.Id == currentUser.Id).Select(x => x.Customer).First();

                ViewBag.CurrentUserId = currentUser.Id;
                return View(Context.Cases.Include(x => x.Owner).Include(x => x.Agent).Where(x => x.Owner.Customer.Id == currentCustomer.Id).ToList());
            }
        }

        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = Context.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        // GET: Cases/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create([Bind(Include = "Id,Title,CaseState,Description,CasePriority,AgentReply")] Case @case)
        {
            var currentUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (ModelState.IsValid)
            {
                @case.Owner = currentUser;
                Context.Cases.Add(@case);
                await Context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(@case);
        }

        [Authorize(Roles = "Agents, Admins")]
        // GET: Cases/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = Context.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        [Authorize(Roles = "Agents, Admins")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "Id,Title, Description, CaseState,AgentReply")] Case @case)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(@case.AgentReply))
                {
                    ModelState.AddModelError("AgentReply", "Please add reply to this case before saving");
                    return View(@case);
                }
                var currentCase = Context.Cases.First(x => x.Id == @case.Id);
                currentCase.AgentReply = @case.AgentReply;
                currentCase.CaseState = @case.CaseState;
                Context.Entry(currentCase).State = EntityState.Modified;
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    var reply = error;
                }
            }
            return View(@case);
        }

        [Authorize(Roles = "Agents, Admins")]
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Case @case = Context.Cases.Find(id);
            if (@case == null)
            {
                return HttpNotFound();
            }
            return View(@case);
        }

        [Authorize(Roles = "Agents, Admins")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            Case @case = Context.Cases.Find(id);
            Context.Cases.Remove(@case);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public virtual async Task<ActionResult> Assign(int id)
        {
            var agentId = User.Identity.GetUserId();
            var currentAgent = await UserManager.FindByIdAsync(agentId);
            var currentCase = Context.Cases.First(x => x.Id == id);
            currentCase.Agent = currentAgent;
            currentCase.CaseState = CaseState.Assigned;
            Context.Entry(currentCase).State = EntityState.Modified;
            var saveResult = await Context.SaveChangesAsync();

            return View(MVC.Cases.Views.Index, Context.Cases.Include(x => x.Owner).ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
