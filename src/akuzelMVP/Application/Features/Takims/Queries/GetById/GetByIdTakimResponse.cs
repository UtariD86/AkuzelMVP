using NArchitecture.Core.Application.Responses;

namespace Application.Features.Takims.Queries.GetById;

public class GetByIdTakimResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KurucuId { get; set; }
    public string Adı { get; set; }
    public double Cuzdan { get; set; }
    public Guid DuzenleyenId { get; set; }
}