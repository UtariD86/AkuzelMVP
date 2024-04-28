using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BakiyeGecmisiConfiguration : IEntityTypeConfiguration<BakiyeGecmisi>
{
    public void Configure(EntityTypeBuilder<BakiyeGecmisi> builder)
    {
        builder.ToTable("BakiyeGecmisis").HasKey(bg => bg.Id);

        builder.Property(bg => bg.Id).HasColumnName("Id").IsRequired();
        builder.Property(bg => bg.LogType).HasColumnName("LogType").IsRequired();
        builder.Property(bg => bg.Id1).HasColumnName("Id1").IsRequired();
        builder.Property(bg => bg.Id2).HasColumnName("Id2");
        builder.Property(bg => bg.SiparisId).HasColumnName("SiparisId");
        builder.Property(bg => bg.KomisyonOrani).HasColumnName("KomisyonOrani").IsRequired();
        builder.Property(bg => bg.Kazanc).HasColumnName("Kazanc").IsRequired();
        builder.Property(bg => bg.Aciklama).HasColumnName("Aciklama").IsRequired();
        builder.Property(bg => bg.BakiyeDegisimi).HasColumnName("BakiyeDegisimi").IsRequired();
        builder.Property(bg => bg.Onay).HasColumnName("Onay").IsRequired();
        builder.Property(bg => bg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bg => bg.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bg => bg.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bg => !bg.DeletedDate.HasValue);
    }
}