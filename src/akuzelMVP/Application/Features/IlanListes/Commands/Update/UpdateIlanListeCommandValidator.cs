using FluentValidation;

namespace Application.Features.IlanListes.Commands.Update;

public class UpdateIlanListeCommandValidator : AbstractValidator<UpdateIlanListeCommand>
{
    public UpdateIlanListeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ListeId).NotEmpty();
        RuleFor(c => c.IlanId).NotEmpty();
    }
}