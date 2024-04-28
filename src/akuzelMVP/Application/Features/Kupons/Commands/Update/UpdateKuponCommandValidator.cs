using FluentValidation;

namespace Application.Features.Kupons.Commands.Update;

public class UpdateKuponCommandValidator : AbstractValidator<UpdateKuponCommand>
{
    public UpdateKuponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KuponType).NotEmpty();
        RuleFor(c => c.Active).NotEmpty();
        RuleFor(c => c.Used).NotEmpty();
        RuleFor(c => c.KuponSahibi).NotEmpty();
        RuleFor(c => c.Adi).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
        RuleFor(c => c.Indirim).NotEmpty();
        RuleFor(c => c.KuponKodu).NotEmpty();
        RuleFor(c => c.Tarih).NotEmpty();
    }
}