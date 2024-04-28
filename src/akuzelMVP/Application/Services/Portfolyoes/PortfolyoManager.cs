using Application.Features.Portfolyoes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Portfolyoes;

public class PortfolyoManager : IPortfolyoService
{
    private readonly IPortfolyoRepository _portfolyoRepository;
    private readonly PortfolyoBusinessRules _portfolyoBusinessRules;

    public PortfolyoManager(IPortfolyoRepository portfolyoRepository, PortfolyoBusinessRules portfolyoBusinessRules)
    {
        _portfolyoRepository = portfolyoRepository;
        _portfolyoBusinessRules = portfolyoBusinessRules;
    }

    public async Task<Portfolyo?> GetAsync(
        Expression<Func<Portfolyo, bool>> predicate,
        Func<IQueryable<Portfolyo>, IIncludableQueryable<Portfolyo, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Portfolyo? portfolyo = await _portfolyoRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return portfolyo;
    }

    public async Task<IPaginate<Portfolyo>?> GetListAsync(
        Expression<Func<Portfolyo, bool>>? predicate = null,
        Func<IQueryable<Portfolyo>, IOrderedQueryable<Portfolyo>>? orderBy = null,
        Func<IQueryable<Portfolyo>, IIncludableQueryable<Portfolyo, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Portfolyo> portfolyoList = await _portfolyoRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return portfolyoList;
    }

    public async Task<Portfolyo> AddAsync(Portfolyo portfolyo)
    {
        Portfolyo addedPortfolyo = await _portfolyoRepository.AddAsync(portfolyo);

        return addedPortfolyo;
    }

    public async Task<Portfolyo> UpdateAsync(Portfolyo portfolyo)
    {
        Portfolyo updatedPortfolyo = await _portfolyoRepository.UpdateAsync(portfolyo);

        return updatedPortfolyo;
    }

    public async Task<Portfolyo> DeleteAsync(Portfolyo portfolyo, bool permanent = false)
    {
        Portfolyo deletedPortfolyo = await _portfolyoRepository.DeleteAsync(portfolyo);

        return deletedPortfolyo;
    }
}
