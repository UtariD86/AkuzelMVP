using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Bildirim : Entity<Guid>
{
    public string Baslik { get; set; }

    public string Icerik { get; set; }

    #region VIRTUAL REFERENCES

    public virtual ICollection<KullaniciBildirim> KullaniciBildirims { get; set; } = default!;
    #endregion
}
