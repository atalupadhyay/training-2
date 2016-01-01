using System.Data.Entity;
using Komsky.Data.Entities;

namespace Komsky.Data.DataAccess
{
public class ApplicationDbContext : DbContext
{
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Ticket> Tickets { get; set; }
    public DbSet<SystemLog> SystemLogs { get; set; }
    public ApplicationDbContext()
        : base("DefaultConnection")
    {
    }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }
}
}