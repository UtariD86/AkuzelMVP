using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SiparisConfiguration : IEntityTypeConfiguration<Siparis>
{
    public void Configure(EntityTypeBuilder<Siparis> builder)
    {
        builder.ToTable("Siparis").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.TeklifId).HasColumnName("TeklifId").IsRequired();
        builder.Property(s => s.SiparisStatus).HasColumnName("SiparisStatus").IsRequired();
        builder.Property(s => s.BitisDate).HasColumnName("BitisDate").IsRequired();
        builder.Property(s => s.KuponId).HasColumnName("KuponId").IsRequired();
        builder.Property(s => s.OdenenUcret).HasColumnName("OdenenUcret").IsRequired();
        builder.Property(s => s.IslemNo).HasColumnName("IslemNo").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}