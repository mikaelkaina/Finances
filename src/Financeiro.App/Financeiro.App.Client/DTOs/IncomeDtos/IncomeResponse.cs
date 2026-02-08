namespace Financeiro.App.Client.DTOs.IncomeDtos;

public record IncomeResponse(
    Guid Id,
    decimal Amount,
    string Description,
    DateTime Date
);