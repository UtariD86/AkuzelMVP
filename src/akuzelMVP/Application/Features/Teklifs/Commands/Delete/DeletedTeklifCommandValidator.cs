using FluentValidation;

namespace Application.Features.Teklifs.Commands.Delete;

public class DeleteTeklifCommandValidator : AbstractValidator<DeleteTeklifCommand>
{
    public DeleteTeklifCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}