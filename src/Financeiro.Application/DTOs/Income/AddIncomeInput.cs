namespace Financeiro.Application.DTOs.Income;

public record AddIncomeInput(
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date
);