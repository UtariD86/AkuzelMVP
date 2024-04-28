using NArchitecture.Core.Application.Responses;

namespace Application.Features.MesajEks.Commands.Delete;

public class DeletedMesajEkResponse : IResponse
{
    public Guid Id { get; set; }
}