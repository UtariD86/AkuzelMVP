using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PortfolyoConfiguration : IEntityTypeConfiguration<Portfolyo>
{
    public void Configure(EntityTypeBuilder<Portfolyo> builder)
    {
        builder.ToTable("Portfolyoes").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.KullaniciId).HasColumnName("KullaniciId").IsRequired();
        builder.Property(p => p.SiparisId).HasColumnName("SiparisId");
        builder.Property(p => p.Baslik).HasColumnName("Baslik").IsRequired();
        builder.Property(p => p.Aciklama).HasColumnName("Aciklama").IsRequired();
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}