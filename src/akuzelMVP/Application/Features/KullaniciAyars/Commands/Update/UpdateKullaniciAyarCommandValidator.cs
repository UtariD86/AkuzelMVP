using FluentValidation;

namespace Application.Features.KullaniciAyars.Commands.Update;

public class UpdateKullaniciAyarCommandValidator : AbstractValidator<UpdateKullaniciAyarCommand>
{
    public UpdateKullaniciAyarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AyarType).NotEmpty();
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.Key).NotEmpty();
        RuleFor(c => c.Value).NotEmpty();
    }
}