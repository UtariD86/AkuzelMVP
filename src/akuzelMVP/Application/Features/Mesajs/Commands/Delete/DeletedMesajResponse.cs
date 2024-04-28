using NArchitecture.Core.Application.Responses;

namespace Application.Features.Mesajs.Commands.Delete;

public class DeletedMesajResponse : IResponse
{
    public Guid Id { get; set; }
}