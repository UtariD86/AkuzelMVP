using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KullaniciBildirimConfiguration : IEntityTypeConfiguration<KullaniciBildirim>
{
    public void Configure(EntityTypeBuilder<KullaniciBildirim> builder)
    {
        builder.ToTable("KullaniciBildirims").HasKey(kb => kb.Id);

        builder.Property(kb => kb.Id).HasColumnName("Id").IsRequired();
        builder.Property(kb => kb.KullaniciId).HasColumnName("KullaniciId").IsRequired();
        builder.Property(kb => kb.BildirimId).HasColumnName("BildirimId").IsRequired();
        builder.Property(kb => kb.Goruldu).HasColumnName("Goruldu").IsRequired();
        builder.Property(kb => kb.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(kb => kb.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(kb => kb.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(kb => kb.Bildirim);
        builder.HasOne(kb => kb.Kullanici);

        builder.HasQueryFilter(kb => !kb.DeletedDate.HasValue);
    }
}