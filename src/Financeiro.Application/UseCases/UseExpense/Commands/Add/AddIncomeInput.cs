namespace Financeiro.Application.UseCases.UseExpense.Commands.Add;

public record AddIncomeInput(
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date
);