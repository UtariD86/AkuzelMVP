using NArchitecture.Core.Application.Responses;

namespace Application.Features.Portfolyoes.Queries.GetById;

public class GetByIdPortfolyoResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KullaniciId { get; set; }
    public Guid? SiparisId { get; set; }
    public string Baslik { get; set; }
    public string Aciklama { get; set; }
}