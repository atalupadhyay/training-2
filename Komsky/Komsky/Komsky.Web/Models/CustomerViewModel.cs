using System;
using System.Collections.Generic;

namespace Komsky.Web.Models
{
    public class CustomerViewModel
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}