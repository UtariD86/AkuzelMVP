using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Liste : Entity<Guid>
{
    public Guid KullaniciId { get; set; }

    public ListeType Type { get; set; }

    public string Adı { get; set; }

    #region VIRTUAL REFERENCES
    public virtual IEnumerable<IlanListe>? IlanListes { get; set; } = default!;
    #endregion

}
