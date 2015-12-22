using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Komsky.Data.Entities;

namespace Komsky.Web.Models
{
public class CustomerViewModel
{
    [Required]
    public Int32 Id { get; set; }
    [Required]
    [MinLength(3)]
    public String Name { get; set; }
    [Required]
    [EmailAddress]
    public String Email { get; set; }
    [Required]
    [Phone]
    public String Phone { get; set; }
    [StringLength(8,MinimumLength = 4)]
    public String PIN { get; set; }
    public IEnumerable<ApplicationUser> Users { get; set; }
    public IEnumerable<ProductViewModel> Products { get; set; }
}
}