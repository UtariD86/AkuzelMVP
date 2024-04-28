using Application.Features.Medyas.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Medyas;

public class MedyaManager : IMedyaService
{
    private readonly IMedyaRepository _medyaRepository;
    private readonly MedyaBusinessRules _medyaBusinessRules;

    public MedyaManager(IMedyaRepository medyaRepository, MedyaBusinessRules medyaBusinessRules)
    {
        _medyaRepository = medyaRepository;
        _medyaBusinessRules = medyaBusinessRules;
    }

    public async Task<Medya?> GetAsync(
        Expression<Func<Medya, bool>> predicate,
        Func<IQueryable<Medya>, IIncludableQueryable<Medya, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Medya? medya = await _medyaRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return medya;
    }

    public async Task<IPaginate<Medya>?> GetListAsync(
        Expression<Func<Medya, bool>>? predicate = null,
        Func<IQueryable<Medya>, IOrderedQueryable<Medya>>? orderBy = null,
        Func<IQueryable<Medya>, IIncludableQueryable<Medya, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Medya> medyaList = await _medyaRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return medyaList;
    }

    public async Task<Medya> AddAsync(Medya medya)
    {
        Medya addedMedya = await _medyaRepository.AddAsync(medya);

        return addedMedya;
    }

    public async Task<Medya> UpdateAsync(Medya medya)
    {
        Medya updatedMedya = await _medyaRepository.UpdateAsync(medya);

        return updatedMedya;
    }

    public async Task<Medya> DeleteAsync(Medya medya, bool permanent = false)
    {
        Medya deletedMedya = await _medyaRepository.DeleteAsync(medya);

        return deletedMedya;
    }
}
