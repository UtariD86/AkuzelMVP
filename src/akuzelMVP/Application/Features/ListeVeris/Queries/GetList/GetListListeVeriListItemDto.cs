using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.ListeVeris.Queries.GetList;

public class GetListListeVeriListItemDto : IDto
{
    public Guid Id { get; set; }
    public ListeVeriType Type { get; set; }
    public Guid? UstId { get; set; }
    public int Derinlik { get; set; }
    public string Deger { get; set; }
    public Guid? EkId { get; set; }
    public string? EkDeger { get; set; }
    public string? Aciklama { get; set; }
    public Guid DuzenleyenId { get; set; }
}