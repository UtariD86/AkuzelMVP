using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class IlanListeConfiguration : IEntityTypeConfiguration<IlanListe>
{
    public void Configure(EntityTypeBuilder<IlanListe> builder)
    {
        builder.ToTable("IlanListes").HasKey(il => il.Id);

        builder.Property(il => il.Id).HasColumnName("Id").IsRequired();
        builder.Property(il => il.ListeId).HasColumnName("ListeId").IsRequired();
        builder.Property(il => il.IlanId).HasColumnName("IlanId").IsRequired();
        builder.Property(il => il.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(il => il.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(il => il.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(il => il.Liste);
        builder.HasOne(il => il.Ilan);

        builder.HasQueryFilter(il => !il.DeletedDate.HasValue);
    }
}