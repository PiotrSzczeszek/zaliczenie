using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zaliczenie.Data.Entities;

namespace Zaliczenie.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<Company> Companies { get; set; } = null!;
    public virtual DbSet<Client> Clients { get; set; } = null!;
    public virtual DbSet<ClientDocuments> ClientDocuments { get; set; } = null!;
    public virtual DbSet<ClientDocumentTypes> ClientDocumentTypes { get; set; } = null!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}