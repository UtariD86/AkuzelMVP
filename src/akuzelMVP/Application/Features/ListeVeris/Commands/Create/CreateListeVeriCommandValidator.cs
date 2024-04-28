using FluentValidation;

namespace Application.Features.ListeVeris.Commands.Create;

public class CreateListeVeriCommandValidator : AbstractValidator<CreateListeVeriCommand>
{
    public CreateListeVeriCommandValidator()
    {
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Derinlik).NotEmpty();
        RuleFor(c => c.Deger).NotEmpty();
        RuleFor(c => c.DuzenleyenId).NotEmpty();
    }
}