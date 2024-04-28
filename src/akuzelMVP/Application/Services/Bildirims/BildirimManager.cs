using Application.Features.Bildirims.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Bildirims;

public class BildirimManager : IBildirimService
{
    private readonly IBildirimRepository _bildirimRepository;
    private readonly BildirimBusinessRules _bildirimBusinessRules;

    public BildirimManager(IBildirimRepository bildirimRepository, BildirimBusinessRules bildirimBusinessRules)
    {
        _bildirimRepository = bildirimRepository;
        _bildirimBusinessRules = bildirimBusinessRules;
    }

    public async Task<Bildirim?> GetAsync(
        Expression<Func<Bildirim, bool>> predicate,
        Func<IQueryable<Bildirim>, IIncludableQueryable<Bildirim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Bildirim? bildirim = await _bildirimRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return bildirim;
    }

    public async Task<IPaginate<Bildirim>?> GetListAsync(
        Expression<Func<Bildirim, bool>>? predicate = null,
        Func<IQueryable<Bildirim>, IOrderedQueryable<Bildirim>>? orderBy = null,
        Func<IQueryable<Bildirim>, IIncludableQueryable<Bildirim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Bildirim> bildirimList = await _bildirimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return bildirimList;
    }

    public async Task<Bildirim> AddAsync(Bildirim bildirim)
    {
        Bildirim addedBildirim = await _bildirimRepository.AddAsync(bildirim);

        return addedBildirim;
    }

    public async Task<Bildirim> UpdateAsync(Bildirim bildirim)
    {
        Bildirim updatedBildirim = await _bildirimRepository.UpdateAsync(bildirim);

        return updatedBildirim;
    }

    public async Task<Bildirim> DeleteAsync(Bildirim bildirim, bool permanent = false)
    {
        Bildirim deletedBildirim = await _bildirimRepository.DeleteAsync(bildirim);

        return deletedBildirim;
    }
}
