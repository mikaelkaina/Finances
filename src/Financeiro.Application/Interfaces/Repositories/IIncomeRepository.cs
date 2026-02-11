using Financeiro.Domain.Entities;

namespace Financeiro.Application.Interfaces.Repositories;

public interface IIncomeRepository 
{
    Task AddAsync(Income income);
    Task<decimal> GetTotalByMonthAsync(string userId, int month, int year);
    Task<IEnumerable<Income>> GetByUserAsync(string userId);
    Task<Income?> GetByIdAsync(Guid id);
    void Remove(Income income);
}
