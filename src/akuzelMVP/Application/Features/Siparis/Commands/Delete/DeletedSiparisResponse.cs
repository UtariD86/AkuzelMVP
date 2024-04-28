using NArchitecture.Core.Application.Responses;

namespace Application.Features.Siparis.Commands.Delete;

public class DeletedSiparisResponse : IResponse
{
    public Guid Id { get; set; }
}