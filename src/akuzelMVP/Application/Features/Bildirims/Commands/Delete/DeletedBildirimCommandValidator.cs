using FluentValidation;

namespace Application.Features.Bildirims.Commands.Delete;

public class DeleteBildirimCommandValidator : AbstractValidator<DeleteBildirimCommand>
{
    public DeleteBildirimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}