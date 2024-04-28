using NArchitecture.Core.Application.Responses;

namespace Application.Features.Tickets.Commands.Delete;

public class DeletedTicketResponse : IResponse
{
    public Guid Id { get; set; }
}