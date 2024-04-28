using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bildirims.Commands.Create;

public class CreatedBildirimResponse : IResponse
{
    public Guid Id { get; set; }
    public string Baslik { get; set; }
    public string Icerik { get; set; }
}