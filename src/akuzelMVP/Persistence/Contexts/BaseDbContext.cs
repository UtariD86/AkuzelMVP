using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<BakiyeGecmisi> BakiyeGecmisis { get; set; }
    public DbSet<BankaHesap> BankaHesaps { get; set; }
    public DbSet<Bildirim> Bildirims { get; set; }
    public DbSet<Degerlendirme> Degerlendirmes { get; set; }
    public DbSet<Ilan> Ilans { get; set; }
    public DbSet<IlanListe> IlanListes { get; set; }
    public DbSet<KullaniciAyar> KullaniciAyars { get; set; }
    public DbSet<KullaniciBildirim> KullaniciBildirims { get; set; }
    public DbSet<KullaniciTakim> KullaniciTakims { get; set; }
    public DbSet<Kupon> Kupons { get; set; }
    public DbSet<Liste> Listes { get; set; }
    public DbSet<ListeVeri> ListeVeris { get; set; }
    public DbSet<Medya> Medyas { get; set; }
    public DbSet<Mesaj> Mesajs { get; set; }
    public DbSet<MesajEk> MesajEks { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
