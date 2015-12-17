using System;
using Komsky.Data.Entities.Enums;

namespace Komsky.Data.Entities
{
    public class Product
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ProductType Type { get; set; }
        public Customer Customer { get; set; }
    }
}
