using FluentValidation;

namespace Application.Features.Medyas.Commands.Delete;

public class DeleteMedyaCommandValidator : AbstractValidator<DeleteMedyaCommand>
{
    public DeleteMedyaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}