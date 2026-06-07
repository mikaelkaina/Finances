using Financeiro.Domain.Exceptions;
using Menso.Tools.Exceptions;

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
        Validate(userId, amount, date);

        Id = Guid.NewGuid();
        UserId = userId;
        Amount = amount;
        Description = description;
        Date = date; 
    }

    protected void Update(decimal amount, string description, DateTime date)
    {
        Validate(UserId, amount, date);

        Amount = amount;
        Description = description;
        Date = date;
    }

    private static void Validate(string userId, decimal amount, DateTime date)
    {
        Throw.When.NullOrEmpty(userId, "UserID is required.");
        Throw.When.True(amount <= 0, "Amount must be greater than zero.");
        Throw.When.True(date.Date > DateTime.UtcNow.Date, "Date cannot be in the future.");
    }
}
