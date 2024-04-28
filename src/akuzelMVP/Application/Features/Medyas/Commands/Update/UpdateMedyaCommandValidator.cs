using FluentValidation;

namespace Application.Features.Medyas.Commands.Update;

public class UpdateMedyaCommandValidator : AbstractValidator<UpdateMedyaCommand>
{
    public UpdateMedyaCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.MedyaType).NotEmpty();
        RuleFor(c => c.Path).NotEmpty();
        RuleFor(c => c.AidiyetType).NotEmpty();
        RuleFor(c => c.AidiyetId).NotEmpty();
        RuleFor(c => c.DuzenleyenId).NotEmpty();
    }
}