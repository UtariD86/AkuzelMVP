using FluentValidation;

namespace Application.Features.Degerlendirmes.Commands.Delete;

public class DeleteDegerlendirmeCommandValidator : AbstractValidator<DeleteDegerlendirmeCommand>
{
    public DeleteDegerlendirmeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}