using FluentValidation;

namespace Application.Features.KullaniciBildirims.Commands.Delete;

public class DeleteKullaniciBildirimCommandValidator : AbstractValidator<DeleteKullaniciBildirimCommand>
{
    public DeleteKullaniciBildirimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}