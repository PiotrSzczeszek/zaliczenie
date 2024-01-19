using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zaliczenie.Data.Entities;

namespace Zaliczenie.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public virtual DbSet<User> Users { get; set; } = null!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}