using Application.Features.Ilans.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Ilans;

public class IlanManager : IIlanService
{
    private readonly IIlanRepository _ilanRepository;
    private readonly IlanBusinessRules _ilanBusinessRules;

    public IlanManager(IIlanRepository ilanRepository, IlanBusinessRules ilanBusinessRules)
    {
        _ilanRepository = ilanRepository;
        _ilanBusinessRules = ilanBusinessRules;
    }

    public async Task<Ilan?> GetAsync(
        Expression<Func<Ilan, bool>> predicate,
        Func<IQueryable<Ilan>, IIncludableQueryable<Ilan, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Ilan? ilan = await _ilanRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return ilan;
    }

    public async Task<IPaginate<Ilan>?> GetListAsync(
        Expression<Func<Ilan, bool>>? predicate = null,
        Func<IQueryable<Ilan>, IOrderedQueryable<Ilan>>? orderBy = null,
        Func<IQueryable<Ilan>, IIncludableQueryable<Ilan, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Ilan> ilanList = await _ilanRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return ilanList;
    }

    public async Task<Ilan> AddAsync(Ilan ilan)
    {
        Ilan addedIlan = await _ilanRepository.AddAsync(ilan);

        return addedIlan;
    }

    public async Task<Ilan> UpdateAsync(Ilan ilan)
    {
        Ilan updatedIlan = await _ilanRepository.UpdateAsync(ilan);

        return updatedIlan;
    }

    public async Task<Ilan> DeleteAsync(Ilan ilan, bool permanent = false)
    {
        Ilan deletedIlan = await _ilanRepository.DeleteAsync(ilan);

        return deletedIlan;
    }
}
