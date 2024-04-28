using FluentValidation;

namespace Application.Features.Siparis.Commands.Update;

public class UpdateSiparisCommandValidator : AbstractValidator<UpdateSiparisCommand>
{
    public UpdateSiparisCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TeklifId).NotEmpty();
        RuleFor(c => c.SiparisStatus).NotEmpty();
        RuleFor(c => c.BitisDate).NotEmpty();
        RuleFor(c => c.KuponId).NotEmpty();
        RuleFor(c => c.OdenenUcret).NotEmpty();
        RuleFor(c => c.IslemNo).NotEmpty();
    }
}