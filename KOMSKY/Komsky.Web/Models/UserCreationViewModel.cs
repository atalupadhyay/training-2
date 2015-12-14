using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Komsky.Web.Models.Enums;
using Komsky.Web.Models.Validators;

namespace Komsky.Web.Models
{
    [Validator(typeof(UserCreationValidator))]
    public class UserCreationViewModel
    {
        public String Email { get; set; }
        public String Password { get; set; }
        [Display(Name = "Repeat password")]
        public String RepeatPassword { get; set; }
        public Customer Customer { get; set; }
        public Roles Role { get; set; }
        public IEnumerable<Customer> AllCustomers { get; set; }
    }
}