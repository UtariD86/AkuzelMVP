using FluentValidation;

namespace Application.Features.MesajEks.Commands.Update;

public class UpdateMesajEkCommandValidator : AbstractValidator<UpdateMesajEkCommand>
{
    public UpdateMesajEkCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.BildirimMi).NotEmpty();
        RuleFor(c => c.MesajId).NotEmpty();
        RuleFor(c => c.EkType).NotEmpty();
        RuleFor(c => c.Icerik).NotEmpty();
    }
}