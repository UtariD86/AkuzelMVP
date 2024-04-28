using FluentValidation;

namespace Application.Features.BakiyeGecmisis.Commands.Delete;

public class DeleteBakiyeGecmisiCommandValidator : AbstractValidator<DeleteBakiyeGecmisiCommand>
{
    public DeleteBakiyeGecmisiCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}