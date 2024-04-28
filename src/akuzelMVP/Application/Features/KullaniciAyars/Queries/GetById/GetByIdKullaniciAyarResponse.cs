using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.KullaniciAyars.Queries.GetById;

public class GetByIdKullaniciAyarResponse : IResponse
{
    public Guid Id { get; set; }
    public KullaniciAyarType AyarType { get; set; }
    public Guid KullaniciId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}