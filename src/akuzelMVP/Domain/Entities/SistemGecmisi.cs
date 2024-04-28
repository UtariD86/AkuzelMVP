using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SistemGecmisi : Entity<Guid>
{
    public LogType LogType { get; set; }

    public Guid Id1 { get; set; }

    public Guid? Id2 { get; set; }

    public Guid? Id3 { get; set; }

    public string Aciklama { get; set; }

    #region VIRTUAL REFERENCES

    public virtual User? User1 { get; set; }
    public virtual User? User2 { get; set; }
    //public virtual User? User3 { get; set; }

    //devamını düşün
    #endregion
}
