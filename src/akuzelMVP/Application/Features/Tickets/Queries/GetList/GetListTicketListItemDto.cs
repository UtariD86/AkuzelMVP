using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Tickets.Queries.GetList;

public class GetListTicketListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid KullaniciId { get; set; }
    public Guid DepartmanId { get; set; }
    public Guid HizmetId { get; set; }
    public bool Cevaplandı { get; set; }
    public string Baslik { get; set; }
    public string Aciklama { get; set; }
}