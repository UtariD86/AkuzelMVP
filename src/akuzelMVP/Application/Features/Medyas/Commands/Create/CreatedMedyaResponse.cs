using NArchitecture.Core.Application.Responses;
using Domain.Enums;
using Domain.Enums;

namespace Application.Features.Medyas.Commands.Create;

public class CreatedMedyaResponse : IResponse
{
    public Guid Id { get; set; }
    public MedyaType MedyaType { get; set; }
    public string Path { get; set; }
    public MedyaAidiyet AidiyetType { get; set; }
    public Guid AidiyetId { get; set; }
    public Guid DuzenleyenId { get; set; }
}