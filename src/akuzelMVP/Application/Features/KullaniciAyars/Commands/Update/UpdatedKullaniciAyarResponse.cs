using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.KullaniciAyars.Commands.Update;

public class UpdatedKullaniciAyarResponse : IResponse
{
    public Guid Id { get; set; }
    public KullaniciAyarType AyarType { get; set; }
    public Guid KullaniciId { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}