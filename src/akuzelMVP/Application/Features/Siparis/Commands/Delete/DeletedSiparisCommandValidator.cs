using FluentValidation;

namespace Application.Features.Siparis.Commands.Delete;

public class DeleteSiparisCommandValidator : AbstractValidator<DeleteSiparisCommand>
{
    public DeleteSiparisCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}