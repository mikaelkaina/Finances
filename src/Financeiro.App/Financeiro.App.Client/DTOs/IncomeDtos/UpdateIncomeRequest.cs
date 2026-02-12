namespace Financeiro.App.Client.DTOs.IncomeDtos;

public record UpdateIncomeRequest(
    decimal Amount,
    string Description,
    DateTime Date
);