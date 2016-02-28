using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Komsky.Domain.Models;
using Komsky.Services.Handlers;
using Komsky.Web.Models;
using Komsky.Web.Models.Factories;

namespace Komsky.Web.Controllers
{
    [Authorize]
    public partial class CustomerController : Controller
{
    private readonly IBaseHandler<CustomerDomain> _customerHandler;

    public CustomerController(IBaseHandler<CustomerDomain> customerHandler)
    {
        _customerHandler = customerHandler;
    }

    public virtual ActionResult Index()
        {
            return View(_customerHandler.GetAll().Select(CustomerViewModelFactory.Create));
        }

    public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = _customerHandler.GetById(id.Value).CreateCustomerViewModel();

            if (customerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerViewModel);
        }

    public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
    public virtual ActionResult Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerHandler.Add(model.CreateCustomerDomain());
                _customerHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = _customerHandler.GetById(id.Value).CreateCustomerViewModel();

            if (customerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit([Bind(Include = "Id,Name")] CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerHandler.Update(model.CreateCustomerDomain());
                _customerHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = _customerHandler.GetById(id.Value).CreateCustomerViewModel();

            if (customerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            _customerHandler.Delete(id);
            _customerHandler.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _customerHandler.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
