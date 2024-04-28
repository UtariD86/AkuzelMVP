using FluentValidation;

namespace Application.Features.Takims.Commands.Update;

public class UpdateTakimCommandValidator : AbstractValidator<UpdateTakimCommand>
{
    public UpdateTakimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.KurucuId).NotEmpty();
        RuleFor(c => c.Adı).NotEmpty();
        RuleFor(c => c.Cuzdan).NotEmpty();
        RuleFor(c => c.DuzenleyenId).NotEmpty();
    }
}