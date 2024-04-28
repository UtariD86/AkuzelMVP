using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MedyaConfiguration : IEntityTypeConfiguration<Medya>
{
    public void Configure(EntityTypeBuilder<Medya> builder)
    {
        builder.ToTable("Medyas").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.MedyaType).HasColumnName("MedyaType").IsRequired();
        builder.Property(m => m.Path).HasColumnName("Path").IsRequired();
        builder.Property(m => m.AidiyetType).HasColumnName("AidiyetType").IsRequired();
        builder.Property(m => m.AidiyetId).HasColumnName("AidiyetId").IsRequired();
        builder.Property(m => m.DuzenleyenId).HasColumnName("DuzenleyenId").IsRequired();
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}