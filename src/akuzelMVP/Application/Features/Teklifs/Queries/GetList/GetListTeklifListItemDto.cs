using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Teklifs.Queries.GetList;

public class GetListTeklifListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid GonderenId { get; set; }
    public Guid MuhattapId { get; set; }
    public Guid? IlanId { get; set; }
    public string Mesaj { get; set; }
    public double Fiyat { get; set; }
    public TimeSpan Sure { get; set; }
    public TeklifStatus Status { get; set; }
}