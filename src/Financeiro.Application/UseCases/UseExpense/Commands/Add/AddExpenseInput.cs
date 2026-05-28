namespace Financeiro.Application.UseCases.UseExpense.Commands.Add;

public record AddExpenseInput(
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date
);
