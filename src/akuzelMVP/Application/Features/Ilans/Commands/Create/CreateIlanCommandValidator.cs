using FluentValidation;

namespace Application.Features.Ilans.Commands.Create;

public class CreateIlanCommandValidator : AbstractValidator<CreateIlanCommand>
{
    public CreateIlanCommandValidator()
    {
        RuleFor(c => c.KategoriId).NotEmpty();
        RuleFor(c => c.IlanSahibiType).NotEmpty();
        RuleFor(c => c.IlanSahibiId).NotEmpty();
        RuleFor(c => c.IlanNo).NotEmpty();
        RuleFor(c => c.Baslik).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.Fiyat).NotEmpty();
        RuleFor(c => c.Sure).NotEmpty();
        RuleFor(c => c.YayinDurumu).NotEmpty();
    }
}