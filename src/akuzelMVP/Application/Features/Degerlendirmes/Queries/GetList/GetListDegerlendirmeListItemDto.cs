using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Degerlendirmes.Queries.GetList;

public class GetListDegerlendirmeListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid SiparisId { get; set; }
    public Guid ProfilId { get; set; }
    public Guid KullaniciId { get; set; }
    public int Puan { get; set; }
    public string Yorum { get; set; }
    public Guid? UstYorumId { get; set; }
    public bool Onay { get; set; }
    public int Like { get; set; }
    public int Dislike { get; set; }
}