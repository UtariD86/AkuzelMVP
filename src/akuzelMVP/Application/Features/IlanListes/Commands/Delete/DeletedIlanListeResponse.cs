using NArchitecture.Core.Application.Responses;

namespace Application.Features.IlanListes.Commands.Delete;

public class DeletedIlanListeResponse : IResponse
{
    public Guid Id { get; set; }
}