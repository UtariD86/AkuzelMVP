using FluentValidation;

namespace Application.Features.Portfolyoes.Commands.Create;

public class CreatePortfolyoCommandValidator : AbstractValidator<CreatePortfolyoCommand>
{
    public CreatePortfolyoCommandValidator()
    {
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.Baslik).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
    }
}