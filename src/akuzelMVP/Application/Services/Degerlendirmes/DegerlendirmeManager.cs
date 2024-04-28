using Application.Features.Degerlendirmes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Degerlendirmes;

public class DegerlendirmeManager : IDegerlendirmeService
{
    private readonly IDegerlendirmeRepository _degerlendirmeRepository;
    private readonly DegerlendirmeBusinessRules _degerlendirmeBusinessRules;

    public DegerlendirmeManager(IDegerlendirmeRepository degerlendirmeRepository, DegerlendirmeBusinessRules degerlendirmeBusinessRules)
    {
        _degerlendirmeRepository = degerlendirmeRepository;
        _degerlendirmeBusinessRules = degerlendirmeBusinessRules;
    }

    public async Task<Degerlendirme?> GetAsync(
        Expression<Func<Degerlendirme, bool>> predicate,
        Func<IQueryable<Degerlendirme>, IIncludableQueryable<Degerlendirme, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Degerlendirme? degerlendirme = await _degerlendirmeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return degerlendirme;
    }

    public async Task<IPaginate<Degerlendirme>?> GetListAsync(
        Expression<Func<Degerlendirme, bool>>? predicate = null,
        Func<IQueryable<Degerlendirme>, IOrderedQueryable<Degerlendirme>>? orderBy = null,
        Func<IQueryable<Degerlendirme>, IIncludableQueryable<Degerlendirme, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Degerlendirme> degerlendirmeList = await _degerlendirmeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return degerlendirmeList;
    }

    public async Task<Degerlendirme> AddAsync(Degerlendirme degerlendirme)
    {
        Degerlendirme addedDegerlendirme = await _degerlendirmeRepository.AddAsync(degerlendirme);

        return addedDegerlendirme;
    }

    public async Task<Degerlendirme> UpdateAsync(Degerlendirme degerlendirme)
    {
        Degerlendirme updatedDegerlendirme = await _degerlendirmeRepository.UpdateAsync(degerlendirme);

        return updatedDegerlendirme;
    }

    public async Task<Degerlendirme> DeleteAsync(Degerlendirme degerlendirme, bool permanent = false)
    {
        Degerlendirme deletedDegerlendirme = await _degerlendirmeRepository.DeleteAsync(degerlendirme);

        return deletedDegerlendirme;
    }
}
