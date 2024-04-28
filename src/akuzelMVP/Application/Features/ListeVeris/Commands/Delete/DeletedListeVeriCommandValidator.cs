using FluentValidation;

namespace Application.Features.ListeVeris.Commands.Delete;

public class DeleteListeVeriCommandValidator : AbstractValidator<DeleteListeVeriCommand>
{
    public DeleteListeVeriCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}