using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zaliczenie.Data.Entities;

public class ClientDocuments
{
    public string Id { get; set; }
    public string DocumentNumber { get; set; }
    public string AddedByUserId { get; set; }
    public virtual Client Client { get; set; }
    public int ClientId { get; set; }
    public virtual User AddedBy { get; set; }
    public DateTime AddedDate { get; set; }
    public DocumentStatus Status { get; set; }
    public DateTime? LastUpdated { get; set; }
    public int DocumentTypeId { get; set; }
    public virtual ClientDocumentTypes DocumentTypeEntity { get; set; }

    [NotMapped] public string? DocumentType => DocumentTypeEntity?.Name;
}

public enum DocumentStatus
{
    New,
    Processing,
    AdditionalInformationRequired,
    Done
}

public class ClientDocumnetsConfiguration : IEntityTypeConfiguration<ClientDocuments>
{
    public void Configure(EntityTypeBuilder<ClientDocuments> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Status)
            .HasConversion<string>();
        
        builder.HasOne(e => e.AddedBy)
            .WithMany()
            .HasForeignKey(e => e.AddedByUserId)
            .IsRequired();

        builder.Property(e => e.LastUpdated)
            .ValueGeneratedOnUpdate();

        builder.HasOne(e => e.Client)
            .WithMany(e => e.Documents)
            .HasForeignKey(e => e.ClientId)
            .IsRequired();
    }
}