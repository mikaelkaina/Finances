namespace Financeiro.Application.UseCases.UseIncome.Commands.Add;

public record AddIncomeInput(
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date
);