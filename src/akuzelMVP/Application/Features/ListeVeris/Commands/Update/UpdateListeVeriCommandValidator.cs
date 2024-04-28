using FluentValidation;

namespace Application.Features.ListeVeris.Commands.Update;

public class UpdateListeVeriCommandValidator : AbstractValidator<UpdateListeVeriCommand>
{
    public UpdateListeVeriCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Derinlik).NotEmpty();
        RuleFor(c => c.Deger).NotEmpty();
        RuleFor(c => c.DuzenleyenId).NotEmpty();
    }
}