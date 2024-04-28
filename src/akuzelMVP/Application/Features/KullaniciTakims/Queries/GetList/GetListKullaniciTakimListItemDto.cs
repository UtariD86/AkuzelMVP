using NArchitecture.Core.Application.Dtos;

namespace Application.Features.KullaniciTakims.Queries.GetList;

public class GetListKullaniciTakimListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TakimId { get; set; }
    public bool Onay { get; set; }
    public Guid DuzenleyenId { get; set; }
}