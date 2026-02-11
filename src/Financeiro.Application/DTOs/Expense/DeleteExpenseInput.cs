namespace Financeiro.Application.DTOs.Expense;

public record DeleteExpenseInput(
    Guid ExpenseId,
    string UserId
);