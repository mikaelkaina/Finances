namespace Financeiro.Domain.Entities;

public sealed class Income : FinancialEntry
{
    public Income(Guid id, string userId, decimal amount, string description, DateTime date)
        : base(id, userId, amount, description, date)
    {
    }
}
