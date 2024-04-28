using FluentValidation;

namespace Application.Features.Degerlendirmes.Commands.Update;

public class UpdateDegerlendirmeCommandValidator : AbstractValidator<UpdateDegerlendirmeCommand>
{
    public UpdateDegerlendirmeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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