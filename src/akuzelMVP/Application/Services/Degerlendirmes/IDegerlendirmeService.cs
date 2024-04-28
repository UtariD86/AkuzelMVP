using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Degerlendirmes;

public interface IDegerlendirmeService
{
    Task<Degerlendirme?> GetAsync(
        Expression<Func<Degerlendirme, bool>> predicate,
        Func<IQueryable<Degerlendirme>, IIncludableQueryable<Degerlendirme, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Degerlendirme>?> GetListAsync(
        Expression<Func<Degerlendirme, bool>>? predicate = null,
        Func<IQueryable<Degerlendirme>, IOrderedQueryable<Degerlendirme>>? orderBy = null,
        Func<IQueryable<Degerlendirme>, IIncludableQueryable<Degerlendirme, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Degerlendirme> AddAsync(Degerlendirme degerlendirme);
    Task<Degerlendirme> UpdateAsync(Degerlendirme degerlendirme);
    Task<Degerlendirme> DeleteAsync(Degerlendirme degerlendirme, bool permanent = false);
}
