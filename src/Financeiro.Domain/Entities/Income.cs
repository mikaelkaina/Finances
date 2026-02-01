namespace Financeiro.Domain.Entities;

public sealed class Income : FinancialEntry
{
    public Income(string userId, decimal amount, string description, DateTime date)
         : base(userId, amount, description, date)
    {
    }
}
