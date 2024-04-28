using NArchitecture.Core.Application.Responses;

namespace Application.Features.KullaniciAyars.Commands.Delete;

public class DeletedKullaniciAyarResponse : IResponse
{
    public Guid Id { get; set; }
}