using NArchitecture.Core.Application.Responses;

namespace Application.Features.IlanListes.Commands.Create;

public class CreatedIlanListeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ListeId { get; set; }
    public Guid IlanId { get; set; }
}