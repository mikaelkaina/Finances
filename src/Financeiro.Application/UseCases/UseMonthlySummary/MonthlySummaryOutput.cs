namespace Financeiro.Application.UseCases.UseMonthlySummary;

public record MonthlySummaryOutput(
    decimal TotalIncome,
    decimal TotalExpenses,
    decimal Balance
);
