using FluentValidation;

namespace Application.Features.BakiyeGecmisis.Commands.Update;

public class UpdateBakiyeGecmisiCommandValidator : AbstractValidator<UpdateBakiyeGecmisiCommand>
{
    public UpdateBakiyeGecmisiCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LogType).NotEmpty();
        RuleFor(c => c.Id1).NotEmpty();
        RuleFor(c => c.KomisyonOrani).NotEmpty();
        RuleFor(c => c.Kazanc).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
        RuleFor(c => c.BakiyeDegisimi).NotEmpty();
        RuleFor(c => c.Onay).NotEmpty();
    }
}