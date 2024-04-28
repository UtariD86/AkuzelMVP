using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Kupon : Entity<Guid>
{
    public KuponType KuponType { get; set; }

    public bool Active { get; set; }

    public bool Used { get; set; }

    public Tablolar KuponSahibi { get; set; }

    public Guid? KuponSahibiId { get; set; }

    public string Adi { get; set; }

    public string Aciklama { get; set; }

    public double Indirim { get; set; }

    public string KuponKodu { get; set; }

    public DateTime Tarih { get; set; } //bitiş ya da geçerlilik duruma göre

    #region VIRTUAL REFERENCES
    /// <summary>
    /// İlgili verinin Bağlı olduğu Üst Veri
    /// </summary>
    public virtual User? Sahibi { get; set; }

    /// <summary>
    /// İlgili veriye Bağlı alt verilerin Collection'u 
    /// </summary>
    public virtual IEnumerable<Siparis> Siparisler { get; set; } = default!;
    #endregion

}
