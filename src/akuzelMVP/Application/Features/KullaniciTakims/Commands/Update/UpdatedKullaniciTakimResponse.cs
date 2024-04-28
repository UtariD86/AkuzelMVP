using NArchitecture.Core.Application.Responses;

namespace Application.Features.KullaniciTakims.Commands.Update;

public class UpdatedKullaniciTakimResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TakimId { get; set; }
    public bool Onay { get; set; }
    public Guid DuzenleyenId { get; set; }
}