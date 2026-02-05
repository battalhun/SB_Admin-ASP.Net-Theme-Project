using Microsoft.EntityFrameworkCore;
using SB_Admin.Models;
using System.Collections.Generic;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<AdminUser> AdminUsers { get; set; }

    public DbSet<Employee> Employees { get; set; }
}
