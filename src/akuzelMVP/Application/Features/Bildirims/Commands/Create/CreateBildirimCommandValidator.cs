using FluentValidation;

namespace Application.Features.Bildirims.Commands.Create;

public class CreateBildirimCommandValidator : AbstractValidator<CreateBildirimCommand>
{
    public CreateBildirimCommandValidator()
    {
        RuleFor(c => c.Baslik).NotEmpty();
        RuleFor(c => c.Icerik).NotEmpty();
    }
}