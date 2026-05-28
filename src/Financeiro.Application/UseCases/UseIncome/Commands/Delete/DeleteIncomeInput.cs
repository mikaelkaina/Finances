namespace Financeiro.Application.UseCases.UseIncome.Commands.Delete;

public record DeleteIncomeInput(
    Guid IncomeId,
    string UserId
);
