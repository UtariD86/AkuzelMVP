using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class BankaHesap : Entity<Guid>
{
    public bool TakimMi { get; set; }

    public Guid SahipId { get; set; }

    public Banka Banka { get; set; }

    public string HesapAdı { get; set; }

    public string Iban { get; set; }

    public string HesapNo { get; set; }

    #region VIRTUAL REFERENCES
    /// <summary>
    /// Hesap sahibi kullanıcı
    /// </summary>
    public virtual User? HesapSahibiUser { get; set; }

    /// <summary>
    /// Hesap sahibi kullanıcı
    /// </summary>
    public virtual Takim? HesapSahibiTakim { get; set; }

    #endregion
}
