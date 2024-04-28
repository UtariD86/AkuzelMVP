using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.KullaniciAyars.Queries.GetList;

public class GetListKullaniciAyarListItemDto : IDto
{
    public Guid Id { get; set; }
    public KullaniciAyarType AyarType { get; set; }
    public Guid KullaniciId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}