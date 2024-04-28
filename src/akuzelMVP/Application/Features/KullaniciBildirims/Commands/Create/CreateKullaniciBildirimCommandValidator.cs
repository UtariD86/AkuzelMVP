using FluentValidation;

namespace Application.Features.KullaniciBildirims.Commands.Create;

public class CreateKullaniciBildirimCommandValidator : AbstractValidator<CreateKullaniciBildirimCommand>
{
    public CreateKullaniciBildirimCommandValidator()
    {
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.BildirimId).NotEmpty();
        RuleFor(c => c.Goruldu).NotEmpty();
    }
}