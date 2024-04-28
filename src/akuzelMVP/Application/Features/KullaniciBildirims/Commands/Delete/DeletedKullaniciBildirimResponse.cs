using NArchitecture.Core.Application.Responses;

namespace Application.Features.KullaniciBildirims.Commands.Delete;

public class DeletedKullaniciBildirimResponse : IResponse
{
    public Guid Id { get; set; }
}