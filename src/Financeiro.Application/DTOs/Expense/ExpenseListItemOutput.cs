namespace Financeiro.Application.DTOs.Expense;

public record ExpenseListItemOutput(
    Guid Id,
    decimal Amount,
    string Description,
    DateTime Date
);
