using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Listes.Commands.Create;

public class CreatedListeResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KullaniciId { get; set; }
    public ListeType Type { get; set; }
    public string Adı { get; set; }
}