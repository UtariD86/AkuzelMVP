using NArchitecture.Core.Application.Responses;

namespace Application.Features.Degerlendirmes.Commands.Delete;

public class DeletedDegerlendirmeResponse : IResponse
{
    public Guid Id { get; set; }
}