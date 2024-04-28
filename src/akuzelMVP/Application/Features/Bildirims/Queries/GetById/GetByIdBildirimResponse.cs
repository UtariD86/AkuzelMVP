using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bildirims.Queries.GetById;

public class GetByIdBildirimResponse : IResponse
{
    public Guid Id { get; set; }
    public string Baslik { get; set; }
    public string Icerik { get; set; }
}