using Financeiro.Domain.Entities;

namespace Financeiro.Domain.Interfaces.Repositories;

public interface IExpenseRepository
{
    void Add(Expense expense);
    Task<decimal> GetTotalByMonthAsync(string userId, int month, int year);
    Task<IEnumerable<Expense>> GetByUserAsync(string userId);
    Task<Expense?> GetByIdAsync(Guid id);
    void Remove(Expense expense);
}
