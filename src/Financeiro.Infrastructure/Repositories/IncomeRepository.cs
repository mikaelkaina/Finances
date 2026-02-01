using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Entities;
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
        await _context.SaveChangesAsync();
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
}
