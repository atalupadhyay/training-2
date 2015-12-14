using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Komsky.Web.Models;
using Komsky.Web.Models.Enums;
using Microsoft.AspNet.Identity;

namespace Komsky.Web.Controllers
{
    [Authorize(Roles = "Admins")]
    public partial class ManageUsersController : BaseKomskyController
    {
        public virtual ActionResult Index()
        {
            return View(Context.Users.Include(x => x.Customer).ToList().Select
                (x => new UserCreationViewModel
                {
                    Email = x.Email,
                    Customer = x.Customer,
                    Role = GetUserRole(x)
                })
            .ToList());
        }



        /// <summary>
        /// Return Roles enum for provided user. 
        /// If provided user is null then Role is returned for current user.
        /// Warning - sync over async
        /// </summary>
        /// <param name="user">User to check Role for.</param>
        /// <returns></returns>
        private Roles GetUserRole(ApplicationUser user = null)
        {
            //Current user of provided?
            if (user == null)
            {
                return User.IsInRole(Roles.Admins.ToString()) ? Roles.Admins : User.IsInRole(Roles.Agents.ToString()) ? Roles.Agents : Roles.Customers;
            }
            if (UserManager.IsInRole(user.Id, Roles.Admins.ToString()))
            {
                return Roles.Admins;
            }
            if (UserManager.IsInRole(user.Id, Roles.Agents.ToString()))
            {
                return Roles.Agents;
            }

            // For keeping things simple, we assume that user with no roles does not exists 
            // (system doesn't allow for that)
            return Roles.Customers;

        }

        //public virtual async Task<ActionResult> Details(string email)
        //{
        //    if (String.IsNullOrEmpty(email))
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationUser applicationUser = await UserManager.FindByEmailAsync(email);
        //    if (applicationUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var model = new UserCreationViewModel
        //    {
        //        Email = applicationUser.Email,
        //        Company = applicationUser.Company
        //    };
        //    return View(model);
        //}

        // GET: ManageUsers/Create
        public virtual ActionResult Create()
        {
            UserCreationViewModel model = new UserCreationViewModel();
            
            if (Context.Customers.Any())
            {
                model.AllCustomers = Context.Customers;
                return View(model);
            }
            return RedirectToAction(MVC.Customers.ActionNames.Create, MVC.Customers.Name);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(UserCreationViewModel model)
        {
            model.AllCustomers = Context.Customers;

            if (ModelState.IsValid)
            {
                //this is due to using simple dropdown - it fills only 
                model.Customer = Context.Customers.Find(model.Customer.Id);
                //Fluent validation does not include Password requirement for easier editing
                if (String.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("Password", "Password must be provided!");
                    return View(model);
                }

                var newUser = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Customer = model.Customer
                };
                var createdUserResult = await UserManager.CreateAsync(newUser, model.Password);
                if (createdUserResult.Succeeded)
                {
                    var createdUser = await UserManager.FindByEmailAsync(model.Email);
                    var addedToRoleResult = await UserManager.AddToRoleAsync(createdUser.Id, model.Role.ToString());
                    if (addedToRoleResult.Succeeded)
                    {
                        return View(MVC.ManageUsers.Views._CreationConfirmation, model);
                    }
                    ViewBag.ErrorDetails = "Error adding user to role. " + addedToRoleResult.Errors.First();
                    return View(MVC.Shared.Views.Error,
                        new HandleErrorInfo(new ApplicationException(ViewBag.ErrorDetails), MVC.ManageUsers.Name,
                            MVC.ManageUsers.ActionNames.Create));
                }
                var error = createdUserResult.Errors.First();
                ViewBag.ErrorDetails = "Error creating user. " + error;
                return View(MVC.Shared.Views.Error,
                    new HandleErrorInfo(new ApplicationException(ViewBag.ErrorDetails), MVC.ManageUsers.Name,
                        MVC.ManageUsers.ActionNames.Create));
            }



            return View(model);
        }

        // GET: ManageUsers/Edit/5
        public virtual async Task<ActionResult> Edit(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCreationViewModel model = new UserCreationViewModel();
            model.AllCustomers = Context.Customers;

            var currentUser = await UserManager.FindByEmailAsync(email);
            if (currentUser != null)
            {
                model.Email = currentUser.Email;
                model.Customer = currentUser.Customer;
                model.Role = GetUserRole(currentUser);
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(UserCreationViewModel model)
        {
            ViewBag.Error = "";
            ViewBag.Message = "";
            model.AllCustomers = Context.Customers;

            if (ModelState.IsValid)
            {

                //this is due to using simple dropdown - it fills only 
                model.Customer = Context.Customers.Find(model.Customer.Id);
                var currentUser = await UserManager.FindByEmailAsync(model.Email);
                if (currentUser == null)
                {
                    return HttpNotFound();
                }

                currentUser.Customer = model.Customer;

                #region Change password only if provided
                if (!String.IsNullOrEmpty(model.Password))
                {

                    var removePasswordResult = await UserManager.RemovePasswordAsync(currentUser.Id);
                    if (removePasswordResult.Succeeded)
                    {
                        var addPasswordResult = await UserManager.AddPasswordAsync(currentUser.Id, model.Password);
                        if (addPasswordResult.Succeeded)
                        {
                            ViewBag.Message += "Password changed successfully. ";
                        }
                        else
                        {
                            ViewBag.Error += "User password setting error. " + addPasswordResult.Errors.FirstOrDefault();
                        }
                    }
                    else
                    {
                        ViewBag.Error += "User remove password error. " + removePasswordResult.Errors.FirstOrDefault();
                    }

                }
                #endregion

                #region Change role only if different than current

                if (GetUserRole(currentUser) != model.Role)
                {
                    await UserManager.RemoveFromRolesAsync(currentUser.Id, new[] { Roles.Admins.ToString(), Roles.Agents.ToString(), Roles.Customers.ToString() });
                    var addToRoleResult = await UserManager.AddToRoleAsync(currentUser.Id, model.Role.ToString());
                    if (addToRoleResult.Succeeded)
                    {
                        ViewBag.Message += "Role changed successfully.";
                        return View(model);
                    }

                }
                #endregion
            }

            return View(model);
        }



    }
}
