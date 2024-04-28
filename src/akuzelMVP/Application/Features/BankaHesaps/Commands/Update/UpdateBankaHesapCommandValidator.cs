using FluentValidation;

namespace Application.Features.BankaHesaps.Commands.Update;

public class UpdateBankaHesapCommandValidator : AbstractValidator<UpdateBankaHesapCommand>
{
    public UpdateBankaHesapCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TakimMi).NotEmpty();
        RuleFor(c => c.SahipId).NotEmpty();
        RuleFor(c => c.Banka).NotEmpty();
        RuleFor(c => c.HesapAdı).NotEmpty();
        RuleFor(c => c.Iban).NotEmpty();
        RuleFor(c => c.HesapNo).NotEmpty();
    }
}