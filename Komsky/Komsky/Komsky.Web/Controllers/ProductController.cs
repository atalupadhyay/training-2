using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Komsky.Domain.Models;
using Komsky.Services.Handlers;
using Komsky.Web.Models;
using Komsky.Web.Models.Factories;

namespace Komsky.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBaseHandler<ProductDomain> _productHandler;
        private readonly IBaseHandler<CustomerDomain> _customerHandler;

        public ProductController(IBaseHandler<ProductDomain> productHandler, IBaseHandler<CustomerDomain> customerHandler)
        {
            _productHandler = productHandler;
            _customerHandler = customerHandler;
        }

        // GET: Product
        public ActionResult Index()
        {
            var model = _productHandler.GetAll().Select(ProductViewModelFactory.Create);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _productHandler.GetById(id);
            if (model != null)
            {
                return View(model.CreateProductViewModel());
            }
            return HttpNotFound();
        }

        public ActionResult Create()
        {
            ProductViewModel model = new ProductViewModel();
            model.AllCustomers = _customerHandler.GetAll().Select(CustomerViewModelFactory.Create);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productHandler.Add(model.CreateProductDomain());
                _productHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var domain = _productHandler.GetById(id);
            if (domain != null)
            {
                var model = domain.CreateProductViewModel();
                model.AllCustomers = _customerHandler.GetAll().Select(CustomerViewModelFactory.Create);
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productHandler.Update(model.CreateProductDomain());
                _productHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = _productHandler.GetById(id);
            if (model != null)
            {
                return View(model.CreateProductViewModel());
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Delete(ProductViewModel model)
        {
            _productHandler.Delete(model.Id);
            _productHandler.Commit();
            return RedirectToAction("Index");
        }
    }
}
