using NArchitecture.Core.Application.Responses;

namespace Application.Features.Portfolyoes.Commands.Update;

public class UpdatedPortfolyoResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KullaniciId { get; set; }
    public Guid? SiparisId { get; set; }
    public string Baslik { get; set; }
    public string Aciklama { get; set; }
}