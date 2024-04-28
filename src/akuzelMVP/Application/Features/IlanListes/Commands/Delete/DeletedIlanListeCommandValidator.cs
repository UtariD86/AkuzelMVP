using FluentValidation;

namespace Application.Features.IlanListes.Commands.Delete;

public class DeleteIlanListeCommandValidator : AbstractValidator<DeleteIlanListeCommand>
{
    public DeleteIlanListeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}