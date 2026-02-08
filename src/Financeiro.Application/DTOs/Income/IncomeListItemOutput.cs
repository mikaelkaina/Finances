namespace Financeiro.Application.DTOs.Income;

public record IncomeListItemOutput(
    Guid Id,
    decimal Amount,
    string Description,
    DateTime Date
);
