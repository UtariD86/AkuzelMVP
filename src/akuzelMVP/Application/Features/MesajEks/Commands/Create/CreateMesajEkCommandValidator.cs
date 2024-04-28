using FluentValidation;

namespace Application.Features.MesajEks.Commands.Create;

public class CreateMesajEkCommandValidator : AbstractValidator<CreateMesajEkCommand>
{
    public CreateMesajEkCommandValidator()
    {
        RuleFor(c => c.BildirimMi).NotEmpty();
        RuleFor(c => c.MesajId).NotEmpty();
        RuleFor(c => c.EkType).NotEmpty();
        RuleFor(c => c.Icerik).NotEmpty();
    }
}