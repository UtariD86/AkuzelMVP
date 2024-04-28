using FluentValidation;

namespace Application.Features.KullaniciTakims.Commands.Update;

public class UpdateKullaniciTakimCommandValidator : AbstractValidator<UpdateKullaniciTakimCommand>
{
    public UpdateKullaniciTakimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.TakimId).NotEmpty();
        RuleFor(c => c.Onay).NotEmpty();
        RuleFor(c => c.DuzenleyenId).NotEmpty();
    }
}