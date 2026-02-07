using Financeiro.Domain.Entities;

namespace Financeiro.Application.Interfaces.Repositories;

public interface IIncomeRepository //
{
    Task AddAsync(Income income);
    Task<decimal> GetTotalByMonthAsync(string userId, int month, int year);
}
