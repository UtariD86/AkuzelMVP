using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MesajEkConfiguration : IEntityTypeConfiguration<MesajEk>
{
    public void Configure(EntityTypeBuilder<MesajEk> builder)
    {
        builder.ToTable("MesajEks").HasKey(me => me.Id);

        builder.Property(me => me.Id).HasColumnName("Id").IsRequired();
        builder.Property(me => me.BildirimMi).HasColumnName("BildirimMi").IsRequired();
        builder.Property(me => me.MesajId).HasColumnName("MesajId").IsRequired();
        builder.Property(me => me.EkType).HasColumnName("EkType").IsRequired();
        builder.Property(me => me.Icerik).HasColumnName("Icerik").IsRequired();
        builder.Property(me => me.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(me => me.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(me => me.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(me => !me.DeletedDate.HasValue);
    }
}