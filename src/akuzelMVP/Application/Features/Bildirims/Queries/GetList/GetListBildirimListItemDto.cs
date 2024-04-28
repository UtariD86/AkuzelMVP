using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Bildirims.Queries.GetList;

public class GetListBildirimListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Baslik { get; set; }
    public string Icerik { get; set; }
}