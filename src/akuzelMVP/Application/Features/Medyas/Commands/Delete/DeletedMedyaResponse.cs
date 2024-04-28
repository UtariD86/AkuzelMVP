using NArchitecture.Core.Application.Responses;

namespace Application.Features.Medyas.Commands.Delete;

public class DeletedMedyaResponse : IResponse
{
    public Guid Id { get; set; }
}