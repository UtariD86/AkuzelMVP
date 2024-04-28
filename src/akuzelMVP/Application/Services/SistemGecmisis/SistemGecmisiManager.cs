using Application.Features.SistemGecmisis.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.SistemGecmisis;

public class SistemGecmisiManager : ISistemGecmisiService
{
    private readonly ISistemGecmisiRepository _sistemGecmisiRepository;
    private readonly SistemGecmisiBusinessRules _sistemGecmisiBusinessRules;

    public SistemGecmisiManager(ISistemGecmisiRepository sistemGecmisiRepository, SistemGecmisiBusinessRules sistemGecmisiBusinessRules)
    {
        _sistemGecmisiRepository = sistemGecmisiRepository;
        _sistemGecmisiBusinessRules = sistemGecmisiBusinessRules;
    }

    public async Task<SistemGecmisi?> GetAsync(
        Expression<Func<SistemGecmisi, bool>> predicate,
        Func<IQueryable<SistemGecmisi>, IIncludableQueryable<SistemGecmisi, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        SistemGecmisi? sistemGecmisi = await _sistemGecmisiRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return sistemGecmisi;
    }

    public async Task<IPaginate<SistemGecmisi>?> GetListAsync(
        Expression<Func<SistemGecmisi, bool>>? predicate = null,
        Func<IQueryable<SistemGecmisi>, IOrderedQueryable<SistemGecmisi>>? orderBy = null,
        Func<IQueryable<SistemGecmisi>, IIncludableQueryable<SistemGecmisi, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<SistemGecmisi> sistemGecmisiList = await _sistemGecmisiRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sistemGecmisiList;
    }

    public async Task<SistemGecmisi> AddAsync(SistemGecmisi sistemGecmisi)
    {
        SistemGecmisi addedSistemGecmisi = await _sistemGecmisiRepository.AddAsync(sistemGecmisi);

        return addedSistemGecmisi;
    }

    public async Task<SistemGecmisi> UpdateAsync(SistemGecmisi sistemGecmisi)
    {
        SistemGecmisi updatedSistemGecmisi = await _sistemGecmisiRepository.UpdateAsync(sistemGecmisi);

        return updatedSistemGecmisi;
    }

    public async Task<SistemGecmisi> DeleteAsync(SistemGecmisi sistemGecmisi, bool permanent = false)
    {
        SistemGecmisi deletedSistemGecmisi = await _sistemGecmisiRepository.DeleteAsync(sistemGecmisi);

        return deletedSistemGecmisi;
    }
}
