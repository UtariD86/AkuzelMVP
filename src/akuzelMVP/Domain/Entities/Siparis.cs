using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Siparis : Entity<Guid>
{
    public Guid TeklifId { get; set; }

    public TeklifStatus SiparisStatus { get; set; }

    public DateTime BitisDate { get; set; }

    public Guid KuponId { get; set; }

    public double OdenenUcret { get; set; }

    public Guid IslemNo { get; set; }

    #region VIRTUAL REFERENCES
    /// <summary>
    /// Takım kurucusu
    /// </summary>
    public virtual Teklif? Teklif { get; set; }

    /// <summary>
    /// Takım kurucusu
    /// </summary>
    public virtual Kupon? Kupon { get; set; }

    public virtual Portfolyo? Portfolyo { get; set; }

    public virtual IEnumerable<Degerlendirme> Degerlendirmes { get; set; } = default!;

    public virtual IEnumerable<BakiyeGecmisi> BakiyeGecmisis { get; set; } = default!;

    #endregion
}
