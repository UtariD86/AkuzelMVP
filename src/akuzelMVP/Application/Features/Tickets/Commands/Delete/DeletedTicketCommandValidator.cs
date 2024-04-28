using FluentValidation;

namespace Application.Features.Tickets.Commands.Delete;

public class DeleteTicketCommandValidator : AbstractValidator<DeleteTicketCommand>
{
    public DeleteTicketCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}