using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class KullaniciAyar : Entity<Guid>
{
    public KullaniciAyarType AyarType { get; set; }

    public Guid KullaniciId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }

    #region VIRTUAL REFERENCES
    /// <summary>
    /// İlgili verinin Bağlı olduğu Üst Veri
    /// </summary>
    public virtual User? Kullanici { get; set; }

    #endregion
}
