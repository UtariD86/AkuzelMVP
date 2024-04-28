using NArchitecture.Core.Application.Responses;

namespace Application.Features.Tickets.Commands.Update;

public class UpdatedTicketResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KullaniciId { get; set; }
    public Guid DepartmanId { get; set; }
    public Guid HizmetId { get; set; }
    public bool Cevaplandı { get; set; }
    public string Baslik { get; set; }
    public string Aciklama { get; set; }
}