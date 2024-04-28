using NArchitecture.Core.Application.Responses;

namespace Application.Features.Takims.Commands.Delete;

public class DeletedTakimResponse : IResponse
{
    public Guid Id { get; set; }
}