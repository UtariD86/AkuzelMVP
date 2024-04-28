using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.MesajEks.Commands.Update;

public class UpdatedMesajEkResponse : IResponse
{
    public Guid Id { get; set; }
    public bool BildirimMi { get; set; }
    public Guid MesajId { get; set; }
    public MedyaType EkType { get; set; }
    public string Icerik { get; set; }
}