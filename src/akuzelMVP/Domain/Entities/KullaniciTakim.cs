using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
/// <summary>
/// Takım ve kullanıcı bağlantı tablosu
/// </summary>
public class KullaniciTakim : Entity<Guid>
{
    /// <summary>
    /// kullanıcının idsi
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// ilgili takımın idsi
    /// </summary>
    public Guid TakimId { get; set; }

    /// <summary>
    /// kullanıcının kabul durumu
    /// </summary>
    public bool Onay { get; set; }

    public Guid DuzenleyenId { get; set; }

    #region VIRTUAL REFERENCES
    /// <summary>
    /// İlgili verinin Bağlı olduğu Takım
    /// </summary>
    public virtual Takim? Takim { get; set; }


    /// <summary>
    /// İlgili verinin Bağlı olduğu Kullanıcı
    /// </summary>
    public virtual User? Uye { get; set; }

    #endregion
}
