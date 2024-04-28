using NArchitecture.Core.Application.Responses;
using Domain.Enums;
using Domain.Enums;

namespace Application.Features.Kupons.Commands.Create;

public class CreatedKuponResponse : IResponse
{
    public Guid Id { get; set; }
    public KuponType KuponType { get; set; }
    public bool Active { get; set; }
    public bool Used { get; set; }
    public Tablolar KuponSahibi { get; set; }
    public Guid? KuponSahibiId { get; set; }
    public string Adi { get; set; }
    public string Aciklama { get; set; }
    public double Indirim { get; set; }
    public string KuponKodu { get; set; }
    public DateTime Tarih { get; set; }
}