using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TakimConfiguration : IEntityTypeConfiguration<Takim>
{
    public void Configure(EntityTypeBuilder<Takim> builder)
    {
        builder.ToTable("Takims").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.KurucuId).HasColumnName("KurucuId").IsRequired();
        builder.Property(t => t.Adı).HasColumnName("Adı").IsRequired();
        builder.Property(t => t.Cuzdan).HasColumnName("Cuzdan").IsRequired();
        builder.Property(t => t.DuzenleyenId).HasColumnName("DuzenleyenId").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(t => t.Kurucu);
        builder.HasMany(t => t.KullaniciTakim);
        builder.HasMany(t => t.BankaHesaplari);

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}