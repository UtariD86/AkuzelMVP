using FluentValidation;

namespace Application.Features.Listes.Commands.Update;

public class UpdateListeCommandValidator : AbstractValidator<UpdateListeCommand>
{
    public UpdateListeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Adı).NotEmpty();
    }
}