using NArchitecture.Core.Application.Dtos;
using Domain.Enums;

namespace Application.Features.Siparis.Queries.GetList;

public class GetListSiparisListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid TeklifId { get; set; }
    public TeklifStatus SiparisStatus { get; set; }
    public DateTime BitisDate { get; set; }
    public Guid KuponId { get; set; }
    public double OdenenUcret { get; set; }
    public Guid IslemNo { get; set; }
}