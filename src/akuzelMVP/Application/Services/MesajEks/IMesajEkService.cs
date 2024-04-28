using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.MesajEks;

public interface IMesajEkService
{
    Task<MesajEk?> GetAsync(
        Expression<Func<MesajEk, bool>> predicate,
        Func<IQueryable<MesajEk>, IIncludableQueryable<MesajEk, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<MesajEk>?> GetListAsync(
        Expression<Func<MesajEk, bool>>? predicate = null,
        Func<IQueryable<MesajEk>, IOrderedQueryable<MesajEk>>? orderBy = null,
        Func<IQueryable<MesajEk>, IIncludableQueryable<MesajEk, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<MesajEk> AddAsync(MesajEk mesajEk);
    Task<MesajEk> UpdateAsync(MesajEk mesajEk);
    Task<MesajEk> DeleteAsync(MesajEk mesajEk, bool permanent = false);
}
