using System;
using Komsky.Data.Entities.Enums;

namespace Komsky.Domain.Models
{
    public class ProductDomain
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ProductType Type { get; set; }
        public Int32 CustomerId { get; set; }
        public CustomerDomain Customer { get; set; }

    }
}
