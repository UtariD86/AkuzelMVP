using FluentValidation;

namespace Application.Features.SistemGecmisis.Commands.Delete;

public class DeleteSistemGecmisiCommandValidator : AbstractValidator<DeleteSistemGecmisiCommand>
{
    public DeleteSistemGecmisiCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}