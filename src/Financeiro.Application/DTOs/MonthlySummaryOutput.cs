namespace Financeiro.Application.DTOs;

public record MonthlySummaryOutput(
    decimal TotalIncome,
    decimal TotalExpenses,
    decimal Balance
);
