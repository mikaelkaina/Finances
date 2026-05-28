namespace Financeiro.Application.UseCases.UseIncome.Commands.Update;

public record UpdateIncomeInput(
    Guid IncomeId,
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date
);