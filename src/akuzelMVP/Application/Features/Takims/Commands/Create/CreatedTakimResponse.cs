using NArchitecture.Core.Application.Responses;

namespace Application.Features.Takims.Commands.Create;

public class CreatedTakimResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KurucuId { get; set; }
    public string Adı { get; set; }
    public double Cuzdan { get; set; }
    public Guid DuzenleyenId { get; set; }
}