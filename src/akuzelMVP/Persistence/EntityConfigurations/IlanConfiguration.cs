using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class IlanConfiguration : IEntityTypeConfiguration<Ilan>
{
    public void Configure(EntityTypeBuilder<Ilan> builder)
    {
        builder.ToTable("Ilans").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.KategoriId).HasColumnName("KategoriId").IsRequired();
        builder.Property(i => i.IlanSahibiType).HasColumnName("IlanSahibiType").IsRequired();
        builder.Property(i => i.IlanSahibiId).HasColumnName("IlanSahibiId").IsRequired();
        builder.Property(i => i.IlanNo).HasColumnName("IlanNo").IsRequired();
        builder.Property(i => i.Baslik).HasColumnName("Baslik").IsRequired();
        builder.Property(i => i.Aciklama).HasColumnName("Aciklama").IsRequired();
        builder.Property(i => i.Status).HasColumnName("Status").IsRequired();
        builder.Property(i => i.Fiyat).HasColumnName("Fiyat").IsRequired();
        builder.Property(i => i.Sure).HasColumnName("Sure").IsRequired();
        builder.Property(i => i.YayinDurumu).HasColumnName("YayinDurumu").IsRequired();
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}