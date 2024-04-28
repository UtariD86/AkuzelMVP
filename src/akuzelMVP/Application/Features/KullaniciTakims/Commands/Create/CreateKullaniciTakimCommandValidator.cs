using FluentValidation;

namespace Application.Features.KullaniciTakims.Commands.Create;

public class CreateKullaniciTakimCommandValidator : AbstractValidator<CreateKullaniciTakimCommand>
{
    public CreateKullaniciTakimCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.TakimId).NotEmpty();
        RuleFor(c => c.Onay).NotEmpty();
        RuleFor(c => c.DuzenleyenId).NotEmpty();
    }
}