namespace Financeiro.Application.UseCases.UseExpense.Commands.Update;

public record UpdateExpenseInput(
    Guid ExpenseId,
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date
);
