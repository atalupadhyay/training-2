using System;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNet.Identity;

namespace Komsky.Web.Models.Validators
{
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

            RuleFor(x => x.Customer).NotNull();
            RuleFor(x => x.Password).MustAsync(PasswordCustomLogic).WithMessage("Passwords must be at least 6 characters with minimum two uppercase letters, two digits and two non-character makrs.");
            RuleFor(x => x.RepeatPassword).Equal(x => x.Password).WithMessage("Password must match!");
            RuleFor(x => x.Email).NotNull().EmailAddress();

        }

        private async Task<bool> PasswordCustomLogic(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return true;
            }
            var validationResult =  await _passwordValidator.ValidateAsync(password);
            return validationResult.Succeeded;
        }
    }
}