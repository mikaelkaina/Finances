using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces.Repositories;
using Financeiro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Infrastructure.Repositories;

public class IncomeRepository : IIncomeRepository
{
    private readonly ApplicationDbContext _context;
    public IncomeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Income income)
    {
        await _context.Incomes.AddAsync(income);
    }

    public async Task<Income?> GetByIdAsync(Guid id)
    {
        return await _context.Incomes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Income>> GetByUserAsync(string userId)
    {
        return await _context.Incomes
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.Date)
            .ToListAsync();
    }

    public async Task<decimal> GetTotalByMonthAsync(string userId, int month, int year)
    {
        return await _context.Incomes
            .Where(x => 
            x.UserId == userId &&
            x.Date.Month == month && 
            x.Date.Year == year)
            .SumAsync(x => x.Amount);
    }

    public void Remove(Income income)
    {
        _context.Incomes.Remove(income);
    }
}
