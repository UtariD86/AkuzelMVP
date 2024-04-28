using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TeklifConfiguration : IEntityTypeConfiguration<Teklif>
{
    public void Configure(EntityTypeBuilder<Teklif> builder)
    {
        builder.ToTable("Teklifs").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.GonderenId).HasColumnName("GonderenId").IsRequired();
        builder.Property(t => t.MuhattapId).HasColumnName("MuhattapId").IsRequired();
        builder.Property(t => t.IlanId).HasColumnName("IlanId");
        builder.Property(t => t.Mesaj).HasColumnName("Mesaj").IsRequired();
        builder.Property(t => t.Fiyat).HasColumnName("Fiyat").IsRequired();
        builder.Property(t => t.Sure).HasColumnName("Sure").IsRequired();
        builder.Property(t => t.Status).HasColumnName("Status").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}