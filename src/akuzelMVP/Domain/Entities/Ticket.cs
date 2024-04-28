using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Ticket : Entity<Guid>
{
    public Guid KullaniciId { get; set; }

    public Guid DepartmanId { get; set; }

    public Guid HizmetId { get; set; }

    public bool Cevaplandı { get; set; }

    public string Baslik { get; set; }

    public string Aciklama { get; set; }

    #region VIRTUAL REFERENCES

    public virtual ICollection<Mesaj>? Mesajs { get; set; } = default!;

    public virtual User? Kullanici { get; set; }

    public virtual ListeVeri? Departman { get; set; }

    public virtual ListeVeri? Hizmet { get; set; }
    #endregion
}
