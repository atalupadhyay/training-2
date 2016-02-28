using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using FluentValidation;
using Komsky.Enums;

namespace Komsky.Web.Models
{
    public class ProductViewModel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        [DisplayName("Release date")]
        public DateTime ReleaseDate { get; set; }
        public ProductType Type { get; set; }
        public Int32 CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }

        //---- ViewModel specific ----//
        public IEnumerable<CustomerViewModel> AllCustomers { get; set; }
    }

    public class ProductViewModelValidator : AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x).Must(CustomeRule);
        }

        private bool CustomeRule(ProductViewModel arg)
        {
            //validate ProductViewModel in any way you like here
            return true;
        }
    }
}