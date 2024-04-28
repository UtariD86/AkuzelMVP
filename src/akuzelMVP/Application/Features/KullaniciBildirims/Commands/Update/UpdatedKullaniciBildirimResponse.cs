using NArchitecture.Core.Application.Responses;

namespace Application.Features.KullaniciBildirims.Commands.Update;

public class UpdatedKullaniciBildirimResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KullaniciId { get; set; }
    public Guid BildirimId { get; set; }
    public bool Goruldu { get; set; }
}