using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentWeb.Models;

namespace StudentWeb.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<StudentWeb.Models.Student> Student { get; set; } = default!;

public DbSet<StudentWeb.Models.Dept> Dept { get; set; } = default!;

public DbSet<StudentWeb.Models.StdDeptAss> StdDeptAss { get; set; } = default!;
}
