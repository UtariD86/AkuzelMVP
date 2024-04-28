using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Portfolyoes.Queries.GetList;

public class GetListPortfolyoListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid KullaniciId { get; set; }
    public Guid? SiparisId { get; set; }
    public string Baslik { get; set; }
    public string Aciklama { get; set; }
}