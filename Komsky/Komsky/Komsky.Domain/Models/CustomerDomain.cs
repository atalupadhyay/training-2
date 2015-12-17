using System;
using System.Collections.Generic;

namespace Komsky.Domain.Models
{
    public class CustomerDomain
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<ProductDomain> Products { get; set; }

    }
}
