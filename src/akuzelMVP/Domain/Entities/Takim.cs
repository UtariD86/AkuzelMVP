using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
/// <summary>
/// kullanıcıların arasında oluşturabildiği takımlar (eski ajans)
/// </summary>
public class Takim : Entity<Guid>
{
    /// <summary>
    /// takım kurucusu id
    /// </summary>
    public Guid KurucuId { get; set; }

    /// <summary>
    /// takım adı
    /// </summary>
    public string Adı { get; set; }

    /// <summary>
    /// Takıma ait cüzdan
    /// </summary>
    public double Cuzdan { get; set; }

    public Guid DuzenleyenId { get; set; }

    #region VIRTUAL REFERENCES
    /// <summary>
    /// Takım kurucusu
    /// </summary>
    public virtual User? Kurucu  { get; set; }

    /// <summary>
    /// User takimdaki onaylı ve onaylanmamış üyelerin tamamı
    /// </summary>
    public virtual IEnumerable<KullaniciTakim> KullaniciTakim { get; set; } = default!;


    /// <summary>
    /// User takimdaki onaylı ve onaylanmamış üyelerin tamamı
    /// </summary>
    public virtual IEnumerable<BankaHesap> BankaHesaplari { get; set; } = default!;
    #endregion
}
