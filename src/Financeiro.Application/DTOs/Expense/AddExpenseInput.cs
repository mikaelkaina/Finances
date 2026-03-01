namespace Financeiro.Application.DTOs.Expense;

public record AddExpenseInput(
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date
);
