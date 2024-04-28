using FluentValidation;

namespace Application.Features.KullaniciTakims.Commands.Delete;

public class DeleteKullaniciTakimCommandValidator : AbstractValidator<DeleteKullaniciTakimCommand>
{
    public DeleteKullaniciTakimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}