using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.BankaHesaps.Queries.GetById;

public class GetByIdBankaHesapResponse : IResponse
{
    public Guid Id { get; set; }
    public bool TakimMi { get; set; }
    public Guid SahipId { get; set; }
    public Banka Banka { get; set; }
    public string HesapAdı { get; set; }
    public string Iban { get; set; }
    public string HesapNo { get; set; }
}