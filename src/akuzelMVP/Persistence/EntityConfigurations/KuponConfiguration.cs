using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KuponConfiguration : IEntityTypeConfiguration<Kupon>
{
    public void Configure(EntityTypeBuilder<Kupon> builder)
    {
        builder.ToTable("Kupons").HasKey(k => k.Id);

        builder.Property(k => k.Id).HasColumnName("Id").IsRequired();
        builder.Property(k => k.KuponType).HasColumnName("KuponType").IsRequired();
        builder.Property(k => k.Active).HasColumnName("Active").IsRequired();
        builder.Property(k => k.Used).HasColumnName("Used").IsRequired();
        builder.Property(k => k.KuponSahibi).HasColumnName("KuponSahibi").IsRequired();
        builder.Property(k => k.KuponSahibiId).HasColumnName("KuponSahibiId");
        builder.Property(k => k.Adi).HasColumnName("Adi").IsRequired();
        builder.Property(k => k.Aciklama).HasColumnName("Aciklama").IsRequired();
        builder.Property(k => k.Indirim).HasColumnName("Indirim").IsRequired();
        builder.Property(k => k.KuponKodu).HasColumnName("KuponKodu").IsRequired();
        builder.Property(k => k.Tarih).HasColumnName("Tarih").IsRequired();
        builder.Property(k => k.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(k => k.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(k => k.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(k => !k.DeletedDate.HasValue);
    }
}