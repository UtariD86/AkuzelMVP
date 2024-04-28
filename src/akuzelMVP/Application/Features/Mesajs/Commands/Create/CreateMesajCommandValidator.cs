using FluentValidation;

namespace Application.Features.Mesajs.Commands.Create;

public class CreateMesajCommandValidator : AbstractValidator<CreateMesajCommand>
{
    public CreateMesajCommandValidator()
    {
        RuleFor(c => c.SenderId).NotEmpty();
        RuleFor(c => c.RecieverId).NotEmpty();
        RuleFor(c => c.Icerik).NotEmpty();
        RuleFor(c => c.TimaStamp).NotEmpty();
        RuleFor(c => c.Okundu).NotEmpty();
    }
}