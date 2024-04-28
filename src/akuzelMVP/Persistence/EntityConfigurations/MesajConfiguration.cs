using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MesajConfiguration : IEntityTypeConfiguration<Mesaj>
{
    public void Configure(EntityTypeBuilder<Mesaj> builder)
    {
        builder.ToTable("Mesajs").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.SenderId).HasColumnName("SenderId").IsRequired();
        builder.Property(m => m.RecieverId).HasColumnName("RecieverId").IsRequired();
        builder.Property(m => m.TicketId).HasColumnName("TicketId");
        builder.Property(m => m.Icerik).HasColumnName("Icerik").IsRequired();
        builder.Property(m => m.TimaStamp).HasColumnName("TimaStamp").IsRequired();
        builder.Property(m => m.Okundu).HasColumnName("Okundu").IsRequired();
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}