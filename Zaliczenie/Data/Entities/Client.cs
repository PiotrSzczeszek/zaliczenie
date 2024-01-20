using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zaliczenie.Data.Entities;

public class Client
{
    public int ClientId { get; set; }
    public string ClientName { get; set; }
    public int DayOfMonthForBilling { get; set; }
    public string? AssignedUserId { get; set; }
    public virtual User? AssignedUser { get; set; }
    public virtual ICollection<ClientDocuments> Documents { get; set; }
}

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(e => e.ClientId);
        
        builder.HasOne(e => e.AssignedUser)
            .WithMany()
            .HasForeignKey(e => e.AssignedUserId)
            .IsRequired(false);
    }
}