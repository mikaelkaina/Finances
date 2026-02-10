namespace Financeiro.Application.DTOs.Income;
public record DeleteIncomeInput(
    Guid IncomeId,
    string UserId
);
