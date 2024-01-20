using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zaliczenie.Data.Entities;

public class ClientDocumentTypes
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Company Company { get; set; }
    public int CompanyId { get; set; }
}

public class ClientDocumentTypesConfiguration : IEntityTypeConfiguration<ClientDocumentTypes>
{
    public void Configure(EntityTypeBuilder<ClientDocumentTypes> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId);
    }
}