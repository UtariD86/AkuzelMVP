using FluentValidation;

namespace Application.Features.KullaniciBildirims.Commands.Update;

public class UpdateKullaniciBildirimCommandValidator : AbstractValidator<UpdateKullaniciBildirimCommand>
{
    public UpdateKullaniciBildirimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.BildirimId).NotEmpty();
        RuleFor(c => c.Goruldu).NotEmpty();
    }
}