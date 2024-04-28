using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.MesajEks.Queries.GetList;

public class GetListMesajEkListItemDto : IDto
{
    public Guid Id { get; set; }
    public bool BildirimMi { get; set; }
    public Guid MesajId { get; set; }
    public MedyaType EkType { get; set; }
    public string Icerik { get; set; }
}