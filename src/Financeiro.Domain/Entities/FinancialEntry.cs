using Financeiro.Domain.Exceptions;

namespace Financeiro.Domain.Entities;

public abstract class FinancialEntry
{
    public Guid Id { get; protected set; }
    public string UserId { get; protected set; }
    public decimal Amount { get; protected set; }
    public string Description { get; protected set; }
    public DateTime Date { get; protected set; }

    protected FinancialEntry(string userId, decimal amount, string description, DateTime date)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new DomainException("UserID é obrigatório.");

        if (amount <= 0)
            throw new DomainException("O valor deve ser maior que zero.");

        if (date.Date > DateTime.UtcNow.Date)
            throw new DomainException("A data não pode ser futura.");

       
        UserId = userId;
        Amount = amount;
        Description = description;
        Date = date;
    }
}
