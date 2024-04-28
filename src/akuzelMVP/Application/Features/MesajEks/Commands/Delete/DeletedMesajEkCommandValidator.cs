using FluentValidation;

namespace Application.Features.MesajEks.Commands.Delete;

public class DeleteMesajEkCommandValidator : AbstractValidator<DeleteMesajEkCommand>
{
    public DeleteMesajEkCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}