using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class KullaniciTakimConfiguration : IEntityTypeConfiguration<KullaniciTakim>
{
    public void Configure(EntityTypeBuilder<KullaniciTakim> builder)
    {
        builder.ToTable("KullaniciTakims").HasKey(kt => kt.Id);

        builder.Property(kt => kt.Id).HasColumnName("Id").IsRequired();
        builder.Property(kt => kt.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(kt => kt.TakimId).HasColumnName("TakimId").IsRequired();
        builder.Property(kt => kt.Onay).HasColumnName("Onay").IsRequired();
        builder.Property(kt => kt.DuzenleyenId).HasColumnName("DuzenleyenId").IsRequired();
        builder.Property(kt => kt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(kt => kt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(kt => kt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(kt => kt.Takim);
        builder.HasOne(kt => kt.Uye);

        builder.HasQueryFilter(kt => !kt.DeletedDate.HasValue);
    }
}