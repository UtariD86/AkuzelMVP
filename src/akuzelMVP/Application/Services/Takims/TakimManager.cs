using Application.Features.Takims.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Takims;

public class TakimManager : ITakimService
{
    private readonly ITakimRepository _takimRepository;
    private readonly TakimBusinessRules _takimBusinessRules;

    public TakimManager(ITakimRepository takimRepository, TakimBusinessRules takimBusinessRules)
    {
        _takimRepository = takimRepository;
        _takimBusinessRules = takimBusinessRules;
    }

    public async Task<Takim?> GetAsync(
        Expression<Func<Takim, bool>> predicate,
        Func<IQueryable<Takim>, IIncludableQueryable<Takim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Takim? takim = await _takimRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return takim;
    }

    public async Task<IPaginate<Takim>?> GetListAsync(
        Expression<Func<Takim, bool>>? predicate = null,
        Func<IQueryable<Takim>, IOrderedQueryable<Takim>>? orderBy = null,
        Func<IQueryable<Takim>, IIncludableQueryable<Takim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Takim> takimList = await _takimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return takimList;
    }

    public async Task<Takim> AddAsync(Takim takim)
    {
        Takim addedTakim = await _takimRepository.AddAsync(takim);

        return addedTakim;
    }

    public async Task<Takim> UpdateAsync(Takim takim)
    {
        Takim updatedTakim = await _takimRepository.UpdateAsync(takim);

        return updatedTakim;
    }

    public async Task<Takim> DeleteAsync(Takim takim, bool permanent = false)
    {
        Takim deletedTakim = await _takimRepository.DeleteAsync(takim);

        return deletedTakim;
    }
}
