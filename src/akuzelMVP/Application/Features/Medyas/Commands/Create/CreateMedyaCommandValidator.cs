using FluentValidation;

namespace Application.Features.Medyas.Commands.Create;

public class CreateMedyaCommandValidator : AbstractValidator<CreateMedyaCommand>
{
    public CreateMedyaCommandValidator()
    {
        RuleFor(c => c.MedyaType).NotEmpty();
        RuleFor(c => c.Path).NotEmpty();
        RuleFor(c => c.AidiyetType).NotEmpty();
        RuleFor(c => c.AidiyetId).NotEmpty();
        RuleFor(c => c.DuzenleyenId).NotEmpty();
    }
}