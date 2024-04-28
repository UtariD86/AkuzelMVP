using NArchitecture.Core.Application.Responses;

namespace Application.Features.KullaniciTakims.Commands.Delete;

public class DeletedKullaniciTakimResponse : IResponse
{
    public Guid Id { get; set; }
}