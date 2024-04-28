using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BakiyeGecmisi : Entity<Guid>
{
    public BakiyeLogType LogType { get; set; }

    public Guid Id1 { get; set; }

    public Guid? Id2 { get; set; }

    public Guid? SiparisId { get; set; }

    public double KomisyonOrani { get; set; }

    public double Kazanc { get; set; }

    public string Aciklama { get; set; }

    public double BakiyeDegisimi { get; set; }

    public bool Onay { get; set; }

    #region VIRTUAL REFERENCES

    public virtual User? User1 { get; set; }

    public virtual User? User2 { get; set; }

    public virtual Siparis? Siparis { get; set; }

    #endregion
}
