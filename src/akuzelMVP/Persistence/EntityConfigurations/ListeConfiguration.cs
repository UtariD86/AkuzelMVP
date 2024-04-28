using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ListeConfiguration : IEntityTypeConfiguration<Liste>
{
    public void Configure(EntityTypeBuilder<Liste> builder)
    {
        builder.ToTable("Listes").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.KullaniciId).HasColumnName("KullaniciId").IsRequired();
        builder.Property(l => l.Type).HasColumnName("Type").IsRequired();
        builder.Property(l => l.Adı).HasColumnName("Adı").IsRequired();
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(l => l.IlanListes);

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}