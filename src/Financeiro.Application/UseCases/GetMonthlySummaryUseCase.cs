using Financeiro.Application.DTOs;
using Financeiro.Application.Interfaces.Repositories;

namespace Financeiro.Application.UseCases;

public class GetMonthlySummaryUseCase
{
    private readonly IIncomeRepository _incomeRepository;
    private readonly IExpenseRepository _expenseRepository;

    public GetMonthlySummaryUseCase(IIncomeRepository incomeRepository, IExpenseRepository expenseRepository)
    {
        _incomeRepository = incomeRepository;
        _expenseRepository = expenseRepository;
    }

    public async Task<MonthlySummaryOutput> ExecuteAsync(string userId, int month, int year)
    {
        var totalIncome = await _incomeRepository.GetTotalByMonthAsync(userId, month, year);
        var totalExpense = await _expenseRepository.GetTotalByMonthAsync(userId, month, year);

        return new MonthlySummaryOutput(
            totalIncome,
            totalExpense,
            totalIncome - totalExpense
        );
    }
}
