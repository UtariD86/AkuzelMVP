using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Teklif : Entity<Guid>
{
    public Guid GonderenId { get; set; }

    public Guid MuhattapId { get; set; }

    public Guid? IlanId { get; set; }

    public string Mesaj { get; set; }

    public double Fiyat { get; set; }

    public TimeSpan Sure { get; set; }

    public TeklifStatus Status { get; set; }

    #region VIRTUAL REFERENCES
    /// <summary>
    /// teklifi Gönderen Kullanıcı
    /// </summary>
    public virtual User? Gonderen { get; set; }

    /// <summary>
    /// teklifi Alan Kullanıcı
    /// </summary>
    public virtual User? Muhattap { get; set; }

    /// <summary>
    /// teklifi Alan Kullanıcı
    /// </summary>
    public virtual Ilan? Ilan { get; set; }

    #endregion
}
