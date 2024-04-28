using NArchitecture.Core.Application.Responses;

namespace Application.Features.Portfolyoes.Commands.Delete;

public class DeletedPortfolyoResponse : IResponse
{
    public Guid Id { get; set; }
}