using System;
using Komsky.Data.Entities.Enums;
using FluentValidation.Mvc;

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
}