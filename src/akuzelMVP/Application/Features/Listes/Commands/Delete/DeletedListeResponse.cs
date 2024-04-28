using NArchitecture.Core.Application.Responses;

namespace Application.Features.Listes.Commands.Delete;

public class DeletedListeResponse : IResponse
{
    public Guid Id { get; set; }
}