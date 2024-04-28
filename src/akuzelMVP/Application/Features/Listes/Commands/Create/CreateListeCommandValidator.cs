using FluentValidation;

namespace Application.Features.Listes.Commands.Create;

public class CreateListeCommandValidator : AbstractValidator<CreateListeCommand>
{
    public CreateListeCommandValidator()
    {
        RuleFor(c => c.KullaniciId).NotEmpty();
        RuleFor(c => c.Type).NotEmpty();
        RuleFor(c => c.Adı).NotEmpty();
    }
}