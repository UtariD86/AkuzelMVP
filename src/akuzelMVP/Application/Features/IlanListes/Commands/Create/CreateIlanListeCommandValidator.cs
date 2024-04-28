using FluentValidation;

namespace Application.Features.IlanListes.Commands.Create;

public class CreateIlanListeCommandValidator : AbstractValidator<CreateIlanListeCommand>
{
    public CreateIlanListeCommandValidator()
    {
        RuleFor(c => c.ListeId).NotEmpty();
        RuleFor(c => c.IlanId).NotEmpty();
    }
}