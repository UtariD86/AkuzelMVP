using FluentValidation;

namespace Application.Features.Portfolyoes.Commands.Update;

public class UpdatePortfolyoCommandValidator : AbstractValidator<UpdatePortfolyoCommand>
{
    public UpdatePortfolyoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.Baslik).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
    }
}