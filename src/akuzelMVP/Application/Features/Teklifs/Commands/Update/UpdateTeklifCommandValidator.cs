using FluentValidation;

namespace Application.Features.Teklifs.Commands.Update;

public class UpdateTeklifCommandValidator : AbstractValidator<UpdateTeklifCommand>
{
    public UpdateTeklifCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.GonderenId).NotEmpty();
        RuleFor(c => c.MuhattapId).NotEmpty();
        RuleFor(c => c.Mesaj).NotEmpty();
        RuleFor(c => c.Fiyat).NotEmpty();
        RuleFor(c => c.Sure).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}