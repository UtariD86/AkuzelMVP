using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MesajEk : Entity<Guid>
{
    public bool BildirimMi { get; set; }

    public Guid MesajId { get; set; }

    public MedyaType EkType { get; set; }

    public string Icerik { get; set; }

    #region VIRTUAL REFERENCES

    public virtual Mesaj? Mesaj { get; set; }

    #endregion
}
