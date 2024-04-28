using FluentValidation;

namespace Application.Features.BankaHesaps.Commands.Create;

public class CreateBankaHesapCommandValidator : AbstractValidator<CreateBankaHesapCommand>
{
    public CreateBankaHesapCommandValidator()
    {
        RuleFor(c => c.TakimMi).NotEmpty();
        RuleFor(c => c.SahipId).NotEmpty();
        RuleFor(c => c.Banka).NotEmpty();
        RuleFor(c => c.HesapAdı).NotEmpty();
        RuleFor(c => c.Iban).NotEmpty();
        RuleFor(c => c.HesapNo).NotEmpty();
    }
}