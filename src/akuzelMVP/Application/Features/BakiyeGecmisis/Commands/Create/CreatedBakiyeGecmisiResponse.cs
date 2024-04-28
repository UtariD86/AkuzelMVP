using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.BakiyeGecmisis.Commands.Create;

public class CreatedBakiyeGecmisiResponse : IResponse
{
    public Guid Id { get; set; }
    public BakiyeLogType LogType { get; set; }
    public Guid Id1 { get; set; }
    public Guid? Id2 { get; set; }
    public Guid? SiparisId { get; set; }
    public double KomisyonOrani { get; set; }
    public double Kazanc { get; set; }
    public string Aciklama { get; set; }
    public double BakiyeDegisimi { get; set; }
    public bool Onay { get; set; }
}