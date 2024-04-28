using NArchitecture.Core.Application.Responses;

namespace Application.Features.BakiyeGecmisis.Commands.Delete;

public class DeletedBakiyeGecmisiResponse : IResponse
{
    public Guid Id { get; set; }
}