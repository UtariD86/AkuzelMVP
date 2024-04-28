using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ilans.Commands.Delete;

public class DeletedIlanResponse : IResponse
{
    public Guid Id { get; set; }
}