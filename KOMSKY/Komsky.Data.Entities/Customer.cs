using System;
using System.ComponentModel.DataAnnotations;

namespace Komsky.Web.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}