using FluentValidation;

namespace Application.Features.Mesajs.Commands.Update;

public class UpdateMesajCommandValidator : AbstractValidator<UpdateMesajCommand>
{
    public UpdateMesajCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SenderId).NotEmpty();
        RuleFor(c => c.RecieverId).NotEmpty();
        RuleFor(c => c.Icerik).NotEmpty();
        RuleFor(c => c.TimaStamp).NotEmpty();
        RuleFor(c => c.Okundu).NotEmpty();
    }
}