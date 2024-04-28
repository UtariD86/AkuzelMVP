using Application.Features.Teklifs.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Teklifs;

public class TeklifManager : ITeklifService
{
    private readonly ITeklifRepository _teklifRepository;
    private readonly TeklifBusinessRules _teklifBusinessRules;

    public TeklifManager(ITeklifRepository teklifRepository, TeklifBusinessRules teklifBusinessRules)
    {
        _teklifRepository = teklifRepository;
        _teklifBusinessRules = teklifBusinessRules;
    }

    public async Task<Teklif?> GetAsync(
        Expression<Func<Teklif, bool>> predicate,
        Func<IQueryable<Teklif>, IIncludableQueryable<Teklif, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Teklif? teklif = await _teklifRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return teklif;
    }

    public async Task<IPaginate<Teklif>?> GetListAsync(
        Expression<Func<Teklif, bool>>? predicate = null,
        Func<IQueryable<Teklif>, IOrderedQueryable<Teklif>>? orderBy = null,
        Func<IQueryable<Teklif>, IIncludableQueryable<Teklif, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Teklif> teklifList = await _teklifRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return teklifList;
    }

    public async Task<Teklif> AddAsync(Teklif teklif)
    {
        Teklif addedTeklif = await _teklifRepository.AddAsync(teklif);

        return addedTeklif;
    }

    public async Task<Teklif> UpdateAsync(Teklif teklif)
    {
        Teklif updatedTeklif = await _teklifRepository.UpdateAsync(teklif);

        return updatedTeklif;
    }

    public async Task<Teklif> DeleteAsync(Teklif teklif, bool permanent = false)
    {
        Teklif deletedTeklif = await _teklifRepository.DeleteAsync(teklif);

        return deletedTeklif;
    }
}
