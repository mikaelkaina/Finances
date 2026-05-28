namespace Financeiro.Application.UseCases.UseExpense.Commands.Delete;

public record DeleteIncomeInput(
    Guid IncomeId,
    string UserId
);
