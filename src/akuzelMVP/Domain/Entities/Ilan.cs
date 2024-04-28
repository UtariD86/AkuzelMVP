using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Ilan : Entity<Guid>
{
    public Guid KategoriId { get; set; }

    public IlanSahibiType IlanSahibiType { get; set; }

    public Guid IlanSahibiId { get; set; }

    public Guid IlanNo { get; set; }

    public string Baslik { get; set; }

    public string Aciklama { get; set; }

    public IlanOnayStatus Status { get; set; }

    public double Fiyat { get; set; }

    public TimeSpan Sure { get; set; }

    public IlanYayinStatus YayinDurumu { get; set; }

    #region VIRTUAL REFERENCES
   
    public virtual User? IlanSahibi { get; set; }

    public virtual ListeVeri Kategori { get; set; }

    public virtual ICollection<Teklif> Teklifs { get; set; } = default!;

    public virtual ICollection<IlanListe> IlanListes { get; set; } = default!;

    #endregion

}
