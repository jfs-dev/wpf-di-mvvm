using Microsoft.EntityFrameworkCore;
using wpf_di_mvvm.Models;

namespace wpf_di_mvvm.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
}
