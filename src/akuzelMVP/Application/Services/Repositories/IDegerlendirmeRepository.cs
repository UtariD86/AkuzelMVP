using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDegerlendirmeRepository : IAsyncRepository<Degerlendirme, Guid>, IRepository<Degerlendirme, Guid>
{
}