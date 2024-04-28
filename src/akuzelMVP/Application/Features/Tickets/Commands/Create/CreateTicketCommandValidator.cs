using FluentValidation;

namespace Application.Features.Tickets.Commands.Create;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.DepartmanId).NotEmpty();
        RuleFor(c => c.HizmetId).NotEmpty();
        RuleFor(c => c.Cevaplandı).NotEmpty();
        RuleFor(c => c.Baslik).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
    }
}