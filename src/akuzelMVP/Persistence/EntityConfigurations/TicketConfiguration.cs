using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets").HasKey(t => t.Id);

        builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
        builder.Property(t => t.KullaniciId).HasColumnName("KullaniciId").IsRequired();
        builder.Property(t => t.DepartmanId).HasColumnName("DepartmanId").IsRequired();
        builder.Property(t => t.HizmetId).HasColumnName("HizmetId").IsRequired();
        builder.Property(t => t.Cevaplandı).HasColumnName("Cevaplandı").IsRequired();
        builder.Property(t => t.Baslik).HasColumnName("Baslik").IsRequired();
        builder.Property(t => t.Aciklama).HasColumnName("Aciklama").IsRequired();
        builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(t => t.Kullanici);
        builder.HasOne(t => t.Departman);
        builder.HasOne(t => t.Hizmet);
        builder.HasMany(t => t.Mesajs);

        builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
    }
}