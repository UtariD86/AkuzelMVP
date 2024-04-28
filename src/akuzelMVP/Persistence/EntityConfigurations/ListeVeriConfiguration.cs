using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ListeVeriConfiguration : IEntityTypeConfiguration<ListeVeri>
{
    public void Configure(EntityTypeBuilder<ListeVeri> builder)
    {
        builder.ToTable("ListeVeris").HasKey(lv => lv.Id);

        builder.Property(lv => lv.Id).HasColumnName("Id").IsRequired();
        builder.Property(lv => lv.Type).HasColumnName("Type").IsRequired();
        builder.Property(lv => lv.UstId).HasColumnName("UstId");
        builder.Property(lv => lv.Derinlik).HasColumnName("Derinlik").IsRequired();
        builder.Property(lv => lv.Deger).HasColumnName("Deger").IsRequired();
        builder.Property(lv => lv.EkId).HasColumnName("EkId");
        builder.Property(lv => lv.EkDeger).HasColumnName("EkDeger");
        builder.Property(lv => lv.Aciklama).HasColumnName("Aciklama");
        builder.Property(lv => lv.DuzenleyenId).HasColumnName("DuzenleyenId").IsRequired();
        builder.Property(lv => lv.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lv => lv.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lv => lv.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(lv => !lv.DeletedDate.HasValue);
    }
}