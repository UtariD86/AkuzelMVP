using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class KullaniciBildirim : Entity<Guid>
{
    public Guid KullaniciId { get; set; }

    public Guid BildirimId { get; set; }

    public bool Goruldu { get; set; }

    #region VIRTUAL REFERENCES

    public virtual User? Kullanici { get; set; }

    public virtual Bildirim? Bildirim { get; set; }

    #endregion
}
