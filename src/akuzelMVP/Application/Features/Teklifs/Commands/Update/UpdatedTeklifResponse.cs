using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Teklifs.Commands.Update;

public class UpdatedTeklifResponse : IResponse
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