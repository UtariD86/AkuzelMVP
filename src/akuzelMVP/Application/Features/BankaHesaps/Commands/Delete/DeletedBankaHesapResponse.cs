using NArchitecture.Core.Application.Responses;

namespace Application.Features.BankaHesaps.Commands.Delete;

public class DeletedBankaHesapResponse : IResponse
{
    public Guid Id { get; set; }
}