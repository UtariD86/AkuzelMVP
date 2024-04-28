using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
/// <summary>
/// Program işleyişinde kullanılan dinamik listeleri statüleri seçenekleri içerikleri kontrol etmek için yazılmış ana tablodur
/// </summary>
public class ListeVeri : Entity<Guid>
{
    /// <summary>
    /// İlgili verinin hangi tipte olduğunu yani nerede kullanılacağını belirleyen değer.
    /// </summary>
    public ListeVeriType Type { get; set; }

    /// <summary>
    /// İlgili verinin ait alduğu üst değer, ana başlık ya da hiyerarşik olarak üstünün idsi
    /// </summary>
    public Guid? UstId { get; set; }

    /// <summary>
    /// İlgili verinin ağaç yapısındaki hiyerarşik sırası
    /// </summary>
    public int Derinlik { get; set; }

    /// <summary>
    /// İlgili verinin değeri
    /// </summary>
    public string Deger { get; set; }

    /// <summary>
    /// İlgili verinin ilişkili olduğu id Örneğin;
    /// 
    /// +Sosyal Medya için KullanıcıId.
    /// +Departman için MedyaId.
    /// </summary>
    public Guid? EkId { get; set; }

    /// <summary>
    /// İlgili verinin ek değeri. Örneğin; 
    /// 
    /// Slayt için Sıra Numarası(int)
    /// Sosyal Medya için SosyalMedyaPlatform(enum)
    /// site sayfa için SiteSayfaKategori(enum)
    /// </summary>
    public string? EkDeger { get; set; }

    public string? Aciklama { get; set; }

    public Guid DuzenleyenId { get; set; }

    #region VIRTUAL REFERENCES
    /// <summary>
    /// İlgili verinin Bağlı olduğu Üst Veri
    /// </summary>
    public virtual ListeVeri? Parent { get; set; }

    /// <summary>
    /// İlgili veriye Bağlı alt verilerin Collection'u 
    /// </summary>
    public virtual IEnumerable<ListeVeri> Children { get; set; } = default!;

    public virtual IEnumerable<Ilan> Ilanlar { get; set; } = default!;

    public virtual IEnumerable<User> Kullanicilar { get; set; } = default!;
    #endregion
}
