using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class IlanListe : Entity<Guid>
{
    public Guid ListeId { get; set; }

    public Guid IlanId { get; set; }

    #region VIRTUAL REFERENCES

    public virtual Liste? Liste { get; set; }

    public virtual Ilan? Ilan { get; set; }

    #endregion
}
