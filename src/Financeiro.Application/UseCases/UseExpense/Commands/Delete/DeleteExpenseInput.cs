namespace Financeiro.Application.UseCases.UseExpense.Commands.Delete;

public record DeleteExpenseInput(
    Guid ExpenseId,
    string UserId
);