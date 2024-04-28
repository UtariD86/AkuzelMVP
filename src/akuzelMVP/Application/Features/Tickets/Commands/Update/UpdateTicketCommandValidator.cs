using FluentValidation;

namespace Application.Features.Tickets.Commands.Update;

public class UpdateTicketCommandValidator : AbstractValidator<UpdateTicketCommand>
{
    public UpdateTicketCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.DepartmanId).NotEmpty();
        RuleFor(c => c.HizmetId).NotEmpty();
        RuleFor(c => c.Cevaplandı).NotEmpty();
        RuleFor(c => c.Baslik).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
    }
}