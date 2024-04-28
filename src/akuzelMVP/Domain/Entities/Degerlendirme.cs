using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Degerlendirme : Entity<Guid>
{
    public Guid SiparisId { get; set; }

    public Guid ProfilId { get; set; }

    public Guid KullaniciId { get; set; }

    public int Puan { get; set; }

    public string Yorum { get; set; }

    public Guid? UstYorumId { get; set; }

    public bool Onay { get; set; }

    public int Like { get; set; }

    public int Dislike { get; set; }

    #region VIRTUAL REFERENCES

    public virtual Siparis? Siparis { get; set; }

    public virtual User? Profil { get; set; }

    public virtual User? Kullanici { get; set; }

    public virtual Degerlendirme? UstDegerlendirme { get; set; }

    public virtual IEnumerable<Degerlendirme> Cevaplar { get; set; } = default!;
    #endregion
}
