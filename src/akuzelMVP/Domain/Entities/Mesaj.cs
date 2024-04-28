using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Mesaj :Entity<Guid>
{
    public Guid SenderId { get; set; }

    public Guid RecieverId { get; set; }

    public Guid? TicketId { get; set; }

    public string Icerik { get; set; }

    public DateTime TimaStamp { get; set; }

    public bool Okundu { get; set; }

    #region VIRTUAL REFERENCES

    public virtual User? Sender { get; set; }

    public virtual User? Reciever { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual ICollection<MesajEk> MesajEks { get; set; } = default!;
    #endregion
}
