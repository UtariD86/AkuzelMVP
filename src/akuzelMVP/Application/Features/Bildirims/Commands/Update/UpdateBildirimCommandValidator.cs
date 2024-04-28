using FluentValidation;

namespace Application.Features.Bildirims.Commands.Update;

public class UpdateBildirimCommandValidator : AbstractValidator<UpdateBildirimCommand>
{
    public UpdateBildirimCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Baslik).NotEmpty();
        RuleFor(c => c.Icerik).NotEmpty();
    }
}