using NArchitecture.Core.Application.Responses;

namespace Application.Features.SistemGecmisis.Commands.Delete;

public class DeletedSistemGecmisiResponse : IResponse
{
    public Guid Id { get; set; }
}