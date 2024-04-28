using NArchitecture.Core.Application.Dtos;

namespace Application.Features.KullaniciBildirims.Queries.GetList;

public class GetListKullaniciBildirimListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid KullaniciId { get; set; }
    public Guid BildirimId { get; set; }
    public bool Goruldu { get; set; }
}