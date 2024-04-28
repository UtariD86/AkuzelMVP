using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IListeVeriRepository : IAsyncRepository<ListeVeri, Guid>, IRepository<ListeVeri, Guid>
{
}