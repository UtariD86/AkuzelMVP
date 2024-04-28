using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SistemGecmisiConfiguration : IEntityTypeConfiguration<SistemGecmisi>
{
    public void Configure(EntityTypeBuilder<SistemGecmisi> builder)
    {
        builder.ToTable("SistemGecmisis").HasKey(sg => sg.Id);

        builder.Property(sg => sg.Id).HasColumnName("Id").IsRequired();
        builder.Property(sg => sg.LogType).HasColumnName("LogType").IsRequired();
        builder.Property(sg => sg.Id1).HasColumnName("Id1").IsRequired();
        builder.Property(sg => sg.Id2).HasColumnName("Id2");
        builder.Property(sg => sg.Id3).HasColumnName("Id3");
        builder.Property(sg => sg.Aciklama).HasColumnName("Aciklama").IsRequired();
        builder.Property(sg => sg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sg => sg.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sg => sg.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(sg => sg.User1);
        builder.HasOne(sg => sg.User2);

        builder.HasQueryFilter(sg => !sg.DeletedDate.HasValue);
    }
}