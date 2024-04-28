using Application.Features.BakiyeGecmisis.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BakiyeGecmisis;

public class BakiyeGecmisiManager : IBakiyeGecmisiService
{
    private readonly IBakiyeGecmisiRepository _bakiyeGecmisiRepository;
    private readonly BakiyeGecmisiBusinessRules _bakiyeGecmisiBusinessRules;

    public BakiyeGecmisiManager(IBakiyeGecmisiRepository bakiyeGecmisiRepository, BakiyeGecmisiBusinessRules bakiyeGecmisiBusinessRules)
    {
        _bakiyeGecmisiRepository = bakiyeGecmisiRepository;
        _bakiyeGecmisiBusinessRules = bakiyeGecmisiBusinessRules;
    }

    public async Task<BakiyeGecmisi?> GetAsync(
        Expression<Func<BakiyeGecmisi, bool>> predicate,
        Func<IQueryable<BakiyeGecmisi>, IIncludableQueryable<BakiyeGecmisi, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BakiyeGecmisi? bakiyeGecmisi = await _bakiyeGecmisiRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bakiyeGecmisi;
    }

    public async Task<IPaginate<BakiyeGecmisi>?> GetListAsync(
        Expression<Func<BakiyeGecmisi, bool>>? predicate = null,
        Func<IQueryable<BakiyeGecmisi>, IOrderedQueryable<BakiyeGecmisi>>? orderBy = null,
        Func<IQueryable<BakiyeGecmisi>, IIncludableQueryable<BakiyeGecmisi, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BakiyeGecmisi> bakiyeGecmisiList = await _bakiyeGecmisiRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bakiyeGecmisiList;
    }

    public async Task<BakiyeGecmisi> AddAsync(BakiyeGecmisi bakiyeGecmisi)
    {
        BakiyeGecmisi addedBakiyeGecmisi = await _bakiyeGecmisiRepository.AddAsync(bakiyeGecmisi);

        return addedBakiyeGecmisi;
    }

    public async Task<BakiyeGecmisi> UpdateAsync(BakiyeGecmisi bakiyeGecmisi)
    {
        BakiyeGecmisi updatedBakiyeGecmisi = await _bakiyeGecmisiRepository.UpdateAsync(bakiyeGecmisi);

        return updatedBakiyeGecmisi;
    }

    public async Task<BakiyeGecmisi> DeleteAsync(BakiyeGecmisi bakiyeGecmisi, bool permanent = false)
    {
        BakiyeGecmisi deletedBakiyeGecmisi = await _bakiyeGecmisiRepository.DeleteAsync(bakiyeGecmisi);

        return deletedBakiyeGecmisi;
    }
}
