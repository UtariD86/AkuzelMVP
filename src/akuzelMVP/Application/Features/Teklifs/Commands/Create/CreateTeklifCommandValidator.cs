using FluentValidation;

namespace Application.Features.Teklifs.Commands.Create;

public class CreateTeklifCommandValidator : AbstractValidator<CreateTeklifCommand>
{
    public CreateTeklifCommandValidator()
    {
        RuleFor(c => c.GonderenId).NotEmpty();
        RuleFor(c => c.MuhattapId).NotEmpty();
        RuleFor(c => c.Mesaj).NotEmpty();
        RuleFor(c => c.Fiyat).NotEmpty();
        RuleFor(c => c.Sure).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}