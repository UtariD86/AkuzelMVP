using NArchitecture.Core.Application.Responses;

namespace Application.Features.IlanListes.Queries.GetById;

public class GetByIdIlanListeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ListeId { get; set; }
    public Guid IlanId { get; set; }
}