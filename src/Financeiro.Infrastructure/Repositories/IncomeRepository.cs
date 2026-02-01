using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Entities;

namespace Financeiro.Infrastructure.Repositories;

public class IncomeRepository : IIncomeRepository
{
    public Task AddAsync(Income income)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetTotalByMonthAsync(string userId, int month, int year)
    {
        throw new NotImplementedException();
    }
}
