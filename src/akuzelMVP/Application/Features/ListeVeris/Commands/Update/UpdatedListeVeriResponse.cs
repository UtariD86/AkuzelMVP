using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.ListeVeris.Commands.Update;

public class UpdatedListeVeriResponse : IResponse
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