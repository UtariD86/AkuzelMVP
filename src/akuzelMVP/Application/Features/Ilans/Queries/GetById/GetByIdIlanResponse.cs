using NArchitecture.Core.Application.Responses;
using Domain.Enums;
using Domain.Enums;
using Domain.Enums;

namespace Application.Features.Ilans.Queries.GetById;

public class GetByIdIlanResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid KategoriId { get; set; }
    public IlanSahibiType IlanSahibiType { get; set; }
    public Guid IlanSahibiId { get; set; }
    public Guid IlanNo { get; set; }
    public string Baslik { get; set; }
    public string Aciklama { get; set; }
    public IlanOnayStatus Status { get; set; }
    public double Fiyat { get; set; }
    public TimeSpan Sure { get; set; }
    public IlanYayinStatus YayinDurumu { get; set; }
}