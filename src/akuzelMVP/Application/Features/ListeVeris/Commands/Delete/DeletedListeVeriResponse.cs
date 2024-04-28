using NArchitecture.Core.Application.Responses;

namespace Application.Features.ListeVeris.Commands.Delete;

public class DeletedListeVeriResponse : IResponse
{
    public Guid Id { get; set; }
}