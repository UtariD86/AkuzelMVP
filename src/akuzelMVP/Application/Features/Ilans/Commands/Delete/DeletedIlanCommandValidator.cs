using FluentValidation;

namespace Application.Features.Ilans.Commands.Delete;

public class DeleteIlanCommandValidator : AbstractValidator<DeleteIlanCommand>
{
    public DeleteIlanCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}