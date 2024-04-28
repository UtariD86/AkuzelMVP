using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KullaniciAyarConfiguration : IEntityTypeConfiguration<KullaniciAyar>
{
    public void Configure(EntityTypeBuilder<KullaniciAyar> builder)
    {
        builder.ToTable("KullaniciAyars").HasKey(ka => ka.Id);

        builder.Property(ka => ka.Id).HasColumnName("Id").IsRequired();
        builder.Property(ka => ka.AyarType).HasColumnName("AyarType").IsRequired();
        builder.Property(ka => ka.KullaniciId).HasColumnName("KullaniciId").IsRequired();
        builder.Property(ka => ka.Key).HasColumnName("Key").IsRequired();
        builder.Property(ka => ka.Value).HasColumnName("Value").IsRequired();
        builder.Property(ka => ka.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ka => ka.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ka => ka.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(ka => ka.Kullanici);

        builder.HasQueryFilter(ka => !ka.DeletedDate.HasValue);
    }
}