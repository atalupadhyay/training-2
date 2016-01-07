﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Komsky.Web.Models;
using Komsky.Data.Entities;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNet.Identity;

namespace Komsky.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public partial class UserManagementController : AccountController
    {
        public UserManagementController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
            : base(userManager, signInManager)
        { }

        public UserManagementController() : base() { }

        public virtual ActionResult Index()
        {
            List<UserCreationViewModel> model = new List<UserCreationViewModel>();
            foreach (var user in UserManager.Users)
            {
                model.Add(new UserCreationViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = GetUserRole(user)
                });
            }
            return View(model);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
public virtual async Task<ActionResult> Create(UserCreationViewModel model)
{
            if (ModelState.IsValid)
            {

                //Fluent validation does not include Password requirement for easier editing
                if (String.IsNullOrEmpty(model.Password))
                {
                    ModelState.AddModelError("Password", "Password must be provided!");
                    return View(model);
                }

                var newUser = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                var createdUserResult = await UserManager.CreateAsync(newUser, model.Password);
                if (createdUserResult.Succeeded)
                {
                    var createdUser = await UserManager.FindByEmailAsync(model.Email);
                    var addedToRoleResult = await UserManager.AddToRoleAsync(createdUser.Id, model.Role.ToString());
                    if (addedToRoleResult.Succeeded)
                    {
                        return View(MVC.UserManagement.Views._CreationConfirmation, model);
                    }
                    ViewBag.ErrorDetails = "Error adding user to role. " + addedToRoleResult.Errors.First();
                    return View(MVC.Shared.Views.Error,
                        new HandleErrorInfo(new ApplicationException(ViewBag.ErrorDetails), MVC.UserManagement.Name,
                            MVC.UserManagement.ActionNames.Create));
                }
                var error = createdUserResult.Errors.First();
                ViewBag.ErrorDetails = "Error creating user. " + error;
                return View(MVC.Shared.Views.Error,
                    new HandleErrorInfo(new ApplicationException(ViewBag.ErrorDetails), MVC.UserManagement.Name,
                        MVC.UserManagement.ActionNames.Create));
            }
            return View(model);
        }

        [HttpGet]
        public virtual async Task<ActionResult> Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCreationViewModel model = new UserCreationViewModel();

            var currentUser = await UserManager.FindByIdAsync(id);
            if (currentUser != null)
            {
                model.Email = currentUser.Email;
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

            if (ModelState.IsValid)
            {
                var currentUser = await UserManager.FindByEmailAsync(model.Email);
                if (currentUser == null)
                {
                    return HttpNotFound();
                }

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
                    await UserManager.RemoveFromRolesAsync(currentUser.Id, new[] { Roles.Admin.ToString(), Roles.Agent.ToString(), Roles.Customer.ToString() });
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
            if (user == null) //This represents current user
            {
                return User.IsInRole(Roles.Admin.ToString()) ? Roles.Admin : User.IsInRole(Roles.Agent.ToString()) ? Roles.Agent : Roles.Customer;
            }
            if (UserManager.IsInRole(user.Id, Roles.Admin.ToString())) //other admin
            {
                return Roles.Admin;
            }
            if (UserManager.IsInRole(user.Id, Roles.Agent.ToString())) //other - agent
            {
                return Roles.Agent;
            }
            // For keeping things simple, we assume that user with no roles does not exists 
            // (system doesn't allow for that)
            return Roles.Customer;
        }
    }
}
