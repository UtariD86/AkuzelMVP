using FluentValidation;

namespace Application.Features.Listes.Commands.Delete;

public class DeleteListeCommandValidator : AbstractValidator<DeleteListeCommand>
{
    public DeleteListeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}