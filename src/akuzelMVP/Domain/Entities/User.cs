using Domain.Enums;
using System.Diagnostics;

namespace Domain.Entities;

public class User : NArchitecture.Core.Security.Entities.User<Guid>
{

    public Guid TakimId { get; set; }

    public double Cuzdan { get; set; }

    public Guid DepartmanId { get; set; } // listeveri

    public Guid IlId { get; set; }

    public Guid IlceId { get; set; }

    public string Adı { get; set; }

    public string Soyadı { get; set; }

    public string Unvan { get; set; }

    public KullaniciUzmanlik Uzmanlik { get; set; }

    public string Adres { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = default!;
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = default!;
    public virtual ICollection<OtpAuthenticator> OtpAuthenticators { get; set; } = default!;
    public virtual ICollection<EmailAuthenticator> EmailAuthenticators { get; set; } = default!;

    public Guid DuzenleyenId { get; set; }

    #region VIRTUAL REFERENCES
    
    public virtual KullaniciTakim? KullaniciTakim { get; set; }

    public virtual ListeVeri? Departman { get; set; }

    public virtual ListeVeri? Il { get; set; }

    public virtual ListeVeri? Ilce { get; set; }

    public virtual IEnumerable<BankaHesap> BankaHesaps { get; set; } = default!;

    public virtual IEnumerable<KullaniciAyar> KullaniciAyars { get; set; } = default!;

    public virtual IEnumerable<Teklif> Teklifs { get; set; } = default!;

    public virtual IEnumerable<Ilan> Ilans { get; set; } = default!;

    public virtual IEnumerable<Kupon> Kupons { get; set; } = default!;

    public virtual IEnumerable<Degerlendirme> Degerlendirmes { get; set; } = default!;

    public virtual IEnumerable<Mesaj> Mesajs { get; set; } = default!;

    public virtual IEnumerable<Ticket> Tickets { get; set; } = default!;

    public virtual IEnumerable<SistemGecmisi> SistemGecmisis { get; set; } = default!;

    public virtual IEnumerable<BakiyeGecmisi> BakiyeGecmisis { get; set; } = default!;

    public virtual IEnumerable<KullaniciBildirim> KullaniciBildirims { get; set; } = default!;

    #endregion

}
