using NArchitecture.Core.Application.Responses;

namespace Application.Features.Kupons.Commands.Delete;

public class DeletedKuponResponse : IResponse
{
    public Guid Id { get; set; }
}