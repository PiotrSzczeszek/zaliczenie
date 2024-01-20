using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zaliczenie.Data.Entities;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = null!;
    public virtual User Creator { get; set; }
    public string CreatorId { get; set; }
    
    public virtual ICollection<User> Members { get; set; }
}

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(e => e.CompanyId);

        builder.Property(e => e.CompanyId)
            .ValueGeneratedOnAdd();
        
        builder.HasOne(e => e.Creator)
            .WithMany()
            .HasForeignKey(e => e.CreatorId)
            .HasPrincipalKey(e => e.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Members)
            .WithOne(e => e.Company)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}