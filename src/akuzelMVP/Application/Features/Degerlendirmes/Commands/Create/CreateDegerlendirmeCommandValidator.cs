using FluentValidation;

namespace Application.Features.Degerlendirmes.Commands.Create;

public class CreateDegerlendirmeCommandValidator : AbstractValidator<CreateDegerlendirmeCommand>
{
    public CreateDegerlendirmeCommandValidator()
    {
        RuleFor(c => c.SiparisId).NotEmpty();
        RuleFor(c => c.ProfilId).NotEmpty();
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.Puan).NotEmpty();
        RuleFor(c => c.Yorum).NotEmpty();
        RuleFor(c => c.Onay).NotEmpty();
        RuleFor(c => c.Like).NotEmpty();
        RuleFor(c => c.Dislike).NotEmpty();
    }
}