using FluentValidation;

namespace Application.Features.Takims.Commands.Create;

public class CreateTakimCommandValidator : AbstractValidator<CreateTakimCommand>
{
    public CreateTakimCommandValidator()
    {
        RuleFor(c => c.KurucuId).NotEmpty();
        RuleFor(c => c.Adı).NotEmpty();
        RuleFor(c => c.Cuzdan).NotEmpty();
        RuleFor(c => c.DuzenleyenId).NotEmpty();
    }
}