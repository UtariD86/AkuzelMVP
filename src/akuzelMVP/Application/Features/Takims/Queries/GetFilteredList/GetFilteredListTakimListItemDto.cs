using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Takims.Queries.GetFilteredList;

public class GetFilteredListTakimListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid KurucuId { get; set; }
    public string Adı { get; set; }
    public double Cuzdan { get; set; }
    public Guid DuzenleyenId { get; set; }
}