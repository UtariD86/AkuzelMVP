using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Listes.Queries.GetList;

public class GetListListeListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid KullaniciId { get; set; }
    public ListeType Type { get; set; }
    public string Adı { get; set; }
}