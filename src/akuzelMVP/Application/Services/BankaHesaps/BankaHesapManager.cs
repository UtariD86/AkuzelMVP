using Application.Features.BankaHesaps.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.BankaHesaps;

public class BankaHesapManager : IBankaHesapService
{
    private readonly IBankaHesapRepository _bankaHesapRepository;
    private readonly BankaHesapBusinessRules _bankaHesapBusinessRules;

    public BankaHesapManager(IBankaHesapRepository bankaHesapRepository, BankaHesapBusinessRules bankaHesapBusinessRules)
    {
        _bankaHesapRepository = bankaHesapRepository;
        _bankaHesapBusinessRules = bankaHesapBusinessRules;
    }

    public async Task<BankaHesap?> GetAsync(
        Expression<Func<BankaHesap, bool>> predicate,
        Func<IQueryable<BankaHesap>, IIncludableQueryable<BankaHesap, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        BankaHesap? bankaHesap = await _bankaHesapRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bankaHesap;
    }

    public async Task<IPaginate<BankaHesap>?> GetListAsync(
        Expression<Func<BankaHesap, bool>>? predicate = null,
        Func<IQueryable<BankaHesap>, IOrderedQueryable<BankaHesap>>? orderBy = null,
        Func<IQueryable<BankaHesap>, IIncludableQueryable<BankaHesap, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<BankaHesap> bankaHesapList = await _bankaHesapRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bankaHesapList;
    }

    public async Task<BankaHesap> AddAsync(BankaHesap bankaHesap)
    {
        BankaHesap addedBankaHesap = await _bankaHesapRepository.AddAsync(bankaHesap);

        return addedBankaHesap;
    }

    public async Task<BankaHesap> UpdateAsync(BankaHesap bankaHesap)
    {
        BankaHesap updatedBankaHesap = await _bankaHesapRepository.UpdateAsync(bankaHesap);

        return updatedBankaHesap;
    }

    public async Task<BankaHesap> DeleteAsync(BankaHesap bankaHesap, bool permanent = false)
    {
        BankaHesap deletedBankaHesap = await _bankaHesapRepository.DeleteAsync(bankaHesap);

        return deletedBankaHesap;
    }
}
