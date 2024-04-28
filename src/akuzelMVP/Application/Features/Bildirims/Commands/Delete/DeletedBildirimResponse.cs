using NArchitecture.Core.Application.Responses;

namespace Application.Features.Bildirims.Commands.Delete;

public class DeletedBildirimResponse : IResponse
{
    public Guid Id { get; set; }
}