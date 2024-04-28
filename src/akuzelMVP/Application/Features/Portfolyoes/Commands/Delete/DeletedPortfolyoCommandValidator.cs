using FluentValidation;

namespace Application.Features.Portfolyoes.Commands.Delete;

public class DeletePortfolyoCommandValidator : AbstractValidator<DeletePortfolyoCommand>
{
    public DeletePortfolyoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}