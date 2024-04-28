using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bildirims.Commands.Update;

public class UpdatedBildirimResponse : IResponse
{
    public Guid Id { get; set; }
    public string Baslik { get; set; }
    public string Icerik { get; set; }
}