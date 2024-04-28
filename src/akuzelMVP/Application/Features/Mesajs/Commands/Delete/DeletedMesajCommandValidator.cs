using FluentValidation;

namespace Application.Features.Mesajs.Commands.Delete;

public class DeleteMesajCommandValidator : AbstractValidator<DeleteMesajCommand>
{
    public DeleteMesajCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}