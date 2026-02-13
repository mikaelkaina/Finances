namespace Financeiro.Application.DTOs.Expense;

public record UpdateExpenseInput(
    Guid ExpenseId,
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date
);
