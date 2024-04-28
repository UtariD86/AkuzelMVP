using FluentValidation;

namespace Application.Features.Kupons.Commands.Delete;

public class DeleteKuponCommandValidator : AbstractValidator<DeleteKuponCommand>
{
    public DeleteKuponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}