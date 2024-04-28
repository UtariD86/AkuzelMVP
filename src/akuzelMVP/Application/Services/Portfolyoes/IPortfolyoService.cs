using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Portfolyoes;

public interface IPortfolyoService
{
    Task<Portfolyo?> GetAsync(
        Expression<Func<Portfolyo, bool>> predicate,
        Func<IQueryable<Portfolyo>, IIncludableQueryable<Portfolyo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Portfolyo>?> GetListAsync(
        Expression<Func<Portfolyo, bool>>? predicate = null,
        Func<IQueryable<Portfolyo>, IOrderedQueryable<Portfolyo>>? orderBy = null,
        Func<IQueryable<Portfolyo>, IIncludableQueryable<Portfolyo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Portfolyo> AddAsync(Portfolyo portfolyo);
    Task<Portfolyo> UpdateAsync(Portfolyo portfolyo);
    Task<Portfolyo> DeleteAsync(Portfolyo portfolyo, bool permanent = false);
}
