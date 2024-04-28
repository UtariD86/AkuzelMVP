using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Hashing;

namespace Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users").HasKey(u => u.Id);

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(u => u.TakimId).HasColumnName("TakimId");
        builder.Property(u => u.Cuzdan).HasColumnName("Cuzdan");
        builder.Property(u => u.DepartmanId).HasColumnName("DepartmanId");
        builder.Property(u => u.IlId).HasColumnName("IlId");
        builder.Property(u => u.IlceId).HasColumnName("IlceId");
        builder.Property(u => u.Adı).HasColumnName("Adı");
        builder.Property(u => u.Soyadı).HasColumnName("Soyadı");
        builder.Property(u => u.Unvan).HasColumnName("Unvan");
        builder.Property(u => u.Uzmanlik).HasColumnName("Uzmanlik");
        builder.Property(u => u.Adres).HasColumnName("Adres");


        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        builder.HasMany(u => u.UserOperationClaims);
        builder.HasMany(u => u.RefreshTokens);
        builder.HasMany(u => u.EmailAuthenticators);
        builder.HasMany(u => u.OtpAuthenticators);

        builder.HasOne(u => u.KullaniciTakim);
        builder.HasOne(u => u.Departman);
        builder.HasOne(u => u.Il);
        builder.HasOne(u => u.Ilce);
        builder.HasMany(u => u.BankaHesaps);
        builder.HasMany(u => u.KullaniciAyars);
        builder.HasMany(u => u.Teklifs);
        builder.HasMany(u => u.Ilans);
        builder.HasMany(u => u.Kupons);
        builder.HasMany(u => u.Degerlendirmes);
        builder.HasMany(u => u.Mesajs);
        builder.HasMany(u => u.Teklifs);
        builder.HasMany(u => u.SistemGecmisis);
        builder.HasMany(u => u.BakiyeGecmisis);
        builder.HasMany(u => u.KullaniciBildirims);
 


        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static Guid AdminId { get; } = Guid.NewGuid();
    private IEnumerable<User> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "Passw0rd!",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User adminUser =
                new()
                {
                    Id = AdminId,
                    Email = "narch@kodlama.io",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Adı = "Admin User",
                    Soyadı = "",
                    DepartmanId = null,
                    IlId = null,
                    IlceId = null,
                    Adres = "Varsayılan Adres",
                    Unvan = ""// Placeholder address
                };
            yield return adminUser;
        }
    }
}
