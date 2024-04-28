using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Portfolyo : Entity<Guid>
{
    public Guid KullaniciId { get; set; }

    public Guid? SiparisId { get; set; }

    public string Baslik { get; set; }

    public string Aciklama { get; set; }

    #region VIRTUAL REFERENCES
    /// <summary>
    /// İlgili verinin Bağlı olduğu Üst Veri
    /// </summary>
    public virtual User? Kullanici { get; set; }

    /// <summary>
    /// İlgili veriye Bağlı alt verilerin Collection'u 
    /// </summary>
    public virtual Siparis? Siparis { get; set; }
    #endregion
}
