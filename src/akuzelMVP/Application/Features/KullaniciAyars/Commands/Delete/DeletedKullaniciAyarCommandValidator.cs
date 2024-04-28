using FluentValidation;

namespace Application.Features.KullaniciAyars.Commands.Delete;

public class DeleteKullaniciAyarCommandValidator : AbstractValidator<DeleteKullaniciAyarCommand>
{
    public DeleteKullaniciAyarCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}