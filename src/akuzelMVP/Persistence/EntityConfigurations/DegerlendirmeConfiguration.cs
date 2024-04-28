using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class DegerlendirmeConfiguration : IEntityTypeConfiguration<Degerlendirme>
{
    public void Configure(EntityTypeBuilder<Degerlendirme> builder)
    {
        builder.ToTable("Degerlendirmes").HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("Id").IsRequired();
        builder.Property(d => d.SiparisId).HasColumnName("SiparisId").IsRequired();
        builder.Property(d => d.ProfilId).HasColumnName("ProfilId").IsRequired();
        builder.Property(d => d.KullaniciId).HasColumnName("KullaniciId").IsRequired();
        builder.Property(d => d.Puan).HasColumnName("Puan").IsRequired();
        builder.Property(d => d.Yorum).HasColumnName("Yorum").IsRequired();
        builder.Property(d => d.UstYorumId).HasColumnName("UstYorumId");
        builder.Property(d => d.Onay).HasColumnName("Onay").IsRequired();
        builder.Property(d => d.Like).HasColumnName("Like").IsRequired();
        builder.Property(d => d.Dislike).HasColumnName("Dislike").IsRequired();
        builder.Property(d => d.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(d => d.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(d => d.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(d => !d.DeletedDate.HasValue);
    }
}