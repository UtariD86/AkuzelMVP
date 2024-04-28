using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IKullaniciBildirimRepository : IAsyncRepository<KullaniciBildirim, Guid>, IRepository<KullaniciBildirim, Guid>
{
}