using System;
using FluentValidation;
using Komsky.Data.Entities.Enums;

namespace Komsky.Web.Models
{
    public class ProductViewModel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ProductType Type { get; set; }
        public CustomerViewModel Customer { get; set; }
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