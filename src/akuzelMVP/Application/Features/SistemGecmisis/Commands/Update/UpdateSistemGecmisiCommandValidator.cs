using FluentValidation;

namespace Application.Features.SistemGecmisis.Commands.Update;

public class UpdateSistemGecmisiCommandValidator : AbstractValidator<UpdateSistemGecmisiCommand>
{
    public UpdateSistemGecmisiCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.LogType).NotEmpty();
        RuleFor(c => c.Id1).NotEmpty();
        RuleFor(c => c.Aciklama).NotEmpty();
    }
}