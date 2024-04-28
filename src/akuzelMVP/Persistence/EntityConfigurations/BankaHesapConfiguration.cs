using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BankaHesapConfiguration : IEntityTypeConfiguration<BankaHesap>
{
    public void Configure(EntityTypeBuilder<BankaHesap> builder)
    {
        builder.ToTable("BankaHesaps").HasKey(bh => bh.Id);

        builder.Property(bh => bh.Id).HasColumnName("Id").IsRequired();
        builder.Property(bh => bh.TakimMi).HasColumnName("TakimMi").IsRequired();
        builder.Property(bh => bh.SahipId).HasColumnName("SahipId").IsRequired();
        builder.Property(bh => bh.Banka).HasColumnName("Banka").IsRequired();
        builder.Property(bh => bh.HesapAdı).HasColumnName("HesapAdı").IsRequired();
        builder.Property(bh => bh.Iban).HasColumnName("Iban").IsRequired();
        builder.Property(bh => bh.HesapNo).HasColumnName("HesapNo").IsRequired();
        builder.Property(bh => bh.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bh => bh.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bh => bh.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bh => !bh.DeletedDate.HasValue);
    }
}