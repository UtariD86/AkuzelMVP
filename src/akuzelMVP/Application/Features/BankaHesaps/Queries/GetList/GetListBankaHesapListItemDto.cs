using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.BankaHesaps.Queries.GetList;

public class GetListBankaHesapListItemDto : IDto
{
    public Guid Id { get; set; }
    public bool TakimMi { get; set; }
    public Guid SahipId { get; set; }
    public Banka Banka { get; set; }
    public string HesapAdı { get; set; }
    public string Iban { get; set; }
    public string HesapNo { get; set; }
}