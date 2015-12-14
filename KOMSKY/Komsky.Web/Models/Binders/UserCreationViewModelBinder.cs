using System;
using System.Web;
using System.Web.Mvc;
using Komsky.Web.Models.Enums;

namespace Komsky.Web.Models.Binders
{
    public class UserCreationViewModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            String userEmail = request.Form.Get("Email");
            String password = request.Form.Get("Password");
            String repeatPassword = request.Form.Get("RepeatPassword");
            String role = request.Form.Get("Role");
            Int32 customerNumber = Int32.Parse(request.Form.Get("Customer"));
            Roles userRole;
            Roles.TryParse(role, out userRole);
            return new UserCreationViewModel
            {
                Email = userEmail,
                Password = password,
                RepeatPassword = repeatPassword,
                Customer = new Customer { Id = customerNumber, Name = "Irrelevant" },
                Role = userRole
            };
        }
    }
}