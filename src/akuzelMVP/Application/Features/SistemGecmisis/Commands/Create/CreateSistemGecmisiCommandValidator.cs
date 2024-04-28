using FluentValidation;

namespace Application.Features.SistemGecmisis.Commands.Create;

public class CreateSistemGecmisiCommandValidator : AbstractValidator<CreateSistemGecmisiCommand>
{
    public CreateSistemGecmisiCommandValidator()
    {
        RuleFor(c => c.LogType).NotEmpty();
        RuleFor(c => c.Id1).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
    }
}