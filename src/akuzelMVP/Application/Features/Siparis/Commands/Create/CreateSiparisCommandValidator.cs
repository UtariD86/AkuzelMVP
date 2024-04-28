using FluentValidation;

namespace Application.Features.Siparis.Commands.Create;

public class CreateSiparisCommandValidator : AbstractValidator<CreateSiparisCommand>
{
    public CreateSiparisCommandValidator()
    {
        RuleFor(c => c.TeklifId).NotEmpty();
        RuleFor(c => c.SiparisStatus).NotEmpty();
        RuleFor(c => c.BitisDate).NotEmpty();
        RuleFor(c => c.KuponId).NotEmpty();
        RuleFor(c => c.OdenenUcret).NotEmpty();
        RuleFor(c => c.IslemNo).NotEmpty();
    }
}