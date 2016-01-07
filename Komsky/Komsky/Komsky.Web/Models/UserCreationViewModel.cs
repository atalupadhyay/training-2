using FluentValidation;
using FluentValidation.Attributes;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Komsky.Web.Models
{
    [Validator(typeof(UserCreationValidator))]
    public class UserCreationViewModel
    {
        public String Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        [Display(Name = "Repeat password")]
        public String RepeatPassword { get; set; }
        public Roles Role { get; set; }
    }

    public class UserCreationValidator : AbstractValidator<UserCreationViewModel>
    {
        private readonly PasswordValidator _passwordValidator;

        public UserCreationValidator()
        {
            _passwordValidator = new PasswordValidator();
            _passwordValidator.RequireNonLetterOrDigit = true;
            _passwordValidator.RequireLowercase = true;
            _passwordValidator.RequireUppercase = true;
            _passwordValidator.RequiredLength = 6;

            RuleFor(x => x.Password).Must(PasswordCustomLogic).WithMessage("Passwords must be at least 6 characters with minimum two uppercase letters, two digits and two non-character makrs.");
            RuleFor(x => x.RepeatPassword).Equal(x => x.Password).WithMessage("Password must match!");
            RuleFor(x => x.Email).NotNull().EmailAddress();

        }

        private bool PasswordCustomLogic(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return true; //password CAN be empty - means, we don't change it
            }
            //using built'in password validation
            var validationResult = _passwordValidator.ValidateAsync(password).Result;
            return validationResult.Succeeded;
        }
    }

public enum Roles
{
    Customer,
    Agent,
    Admin
}
}