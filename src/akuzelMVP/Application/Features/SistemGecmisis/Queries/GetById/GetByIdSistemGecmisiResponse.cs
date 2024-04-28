using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.SistemGecmisis.Queries.GetById;

public class GetByIdSistemGecmisiResponse : IResponse
{
    public Guid Id { get; set; }
    public LogType LogType { get; set; }
    public Guid Id1 { get; set; }
    public Guid? Id2 { get; set; }
    public Guid? Id3 { get; set; }
    public string Aciklama { get; set; }
}