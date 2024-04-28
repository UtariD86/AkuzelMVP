using NArchitecture.Core.Application.Dtos;

namespace Application.Features.IlanListes.Queries.GetList;

public class GetListIlanListeListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ListeId { get; set; }
    public Guid IlanId { get; set; }
}