using NArchitecture.Core.Application.Responses;

namespace Application.Features.KullaniciTakims.Queries.GetById;

public class GetByIdKullaniciTakimResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TakimId { get; set; }
    public bool Onay { get; set; }
    public Guid DuzenleyenId { get; set; }
}