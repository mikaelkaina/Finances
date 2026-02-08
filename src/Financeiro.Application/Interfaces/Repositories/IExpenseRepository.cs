using Financeiro.Domain.Entities;

namespace Financeiro.Application.Interfaces.Repositories;

public interface IExpenseRepository
{
    Task AddAsync(Expense expense);
    Task<decimal> GetTotalByMonthAsync(string userId, int month, int year);
    Task<IEnumerable<Expense>> GetByUserAsync(string userId);
}
