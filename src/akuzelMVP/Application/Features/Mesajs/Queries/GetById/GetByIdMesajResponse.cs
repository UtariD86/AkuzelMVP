using NArchitecture.Core.Application.Responses;

namespace Application.Features.Mesajs.Queries.GetById;

public class GetByIdMesajResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid RecieverId { get; set; }
    public Guid? TicketId { get; set; }
    public string Icerik { get; set; }
    public DateTime TimaStamp { get; set; }
    public bool Okundu { get; set; }
}