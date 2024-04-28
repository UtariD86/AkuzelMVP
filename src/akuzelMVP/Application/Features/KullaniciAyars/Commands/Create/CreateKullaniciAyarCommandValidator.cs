using FluentValidation;

namespace Application.Features.KullaniciAyars.Commands.Create;

public class CreateKullaniciAyarCommandValidator : AbstractValidator<CreateKullaniciAyarCommand>
{
    public CreateKullaniciAyarCommandValidator()
    {
        RuleFor(c => c.AyarType).NotEmpty();
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.Key).NotEmpty();
        RuleFor(c => c.Value).NotEmpty();
    }
}