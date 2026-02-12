namespace Financeiro.Application.DTOs.Income;

public record UpdateIncomeInput(
    Guid IncomeId,
    string UserId,
    decimal Amount,
    string Description,
    DateTime Date
);