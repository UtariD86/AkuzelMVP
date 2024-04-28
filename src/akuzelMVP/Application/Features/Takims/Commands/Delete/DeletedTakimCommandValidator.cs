using FluentValidation;

namespace Application.Features.Takims.Commands.Delete;

public class DeleteTakimCommandValidator : AbstractValidator<DeleteTakimCommand>
{
    public DeleteTakimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}