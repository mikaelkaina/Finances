namespace Financeiro.App.Client.DTOs;

public record AddExpenseRequest(
     decimal Amount,
     string Description,
     DateTime Date
    );

   

