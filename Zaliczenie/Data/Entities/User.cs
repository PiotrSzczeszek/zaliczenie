using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zaliczenie.Data.Entities;

public class User : IdentityUser
{
    public int? CompanyId { get; set; }
    public virtual Company Company { get; set; }
}

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasOne(e => e.Company)
            .WithMany(e => e.Members)
            .HasForeignKey(e => e.CompanyId)
            .IsRequired(false);
    }
}