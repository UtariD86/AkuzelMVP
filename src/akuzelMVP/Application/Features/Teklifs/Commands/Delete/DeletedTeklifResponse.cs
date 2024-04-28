using NArchitecture.Core.Application.Responses;

namespace Application.Features.Teklifs.Commands.Delete;

public class DeletedTeklifResponse : IResponse
{
    public Guid Id { get; set; }
}