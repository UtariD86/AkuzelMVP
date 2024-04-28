using FluentValidation;

namespace Application.Features.BankaHesaps.Commands.Delete;

public class DeleteBankaHesapCommandValidator : AbstractValidator<DeleteBankaHesapCommand>
{
    public DeleteBankaHesapCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}