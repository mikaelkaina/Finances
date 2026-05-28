using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces.Repositories;
using Financeiro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly ApplicationDbContext _context;
    public ExpenseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Expense expense)
    {
        await _context.Expenses.AddAsync(expense);
    }

    public async Task<Expense?> GetByIdAsync(Guid id)
    {
        return await _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Expense>> GetByUserAsync(string userId)
    {
        return await _context.Expenses
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.Date)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalByMonthAsync(string userId, int month, int year)
    {
        return await _context.Expenses
            .Where(x => 
            x.UserId == userId &&
            x.Date.Month == month &&
            x.Date.Year == year)
            .SumAsync(x => x.Amount);
    }

    public void Remove(Expense expense)
    {
        _context.Expenses.Remove(expense);
    }
}
