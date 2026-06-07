using Financeiro.Domain.Entities;
using Financeiro.Domain.Exceptions;
using FluentAssertions;

namespace Finances.Tests.Domain;

public class FinancialEntryTests
{
    [Fact]
    [Trait("Category", "Domain")]
    public void Constructor_WitjValidData_ShoulCreateIncome()
    {
        var userId = Guid.NewGuid().ToString();
        var amount = 150.50m;
        var description = "Sal�rio";
        var date = DateTime.UtcNow;

        var income = new Income(userId, amount, description, date);

        income.UserId.Should().Be(userId);
        income.Amount.Should().Be(amount);
        income.Description.Should().Be(description);
        income.Date.Should().Be(date);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidUserId_ShouldThrowDomainException(string invalidUserId)
    {
        var action = () => new Income(invalidUserId!, 100m, "Description", DateTime.UtcNow);

        action.Should().Throw<ArgumentException>()
            .WithMessage("UserID is required.");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    [InlineData(-0.01)]
    public void Constructor_InvalidAmount_ShouldThrowDomainException(decimal invalidAmount)
    {
        var action = () => new Income("user-123", invalidAmount, "Lanche", DateTime.UtcNow);

        action.Should().Throw<ArgumentException>()
            .WithMessage("Amount must be greater than zero.");
    }

    [Fact]
    public void Constructor_FutureDate_ShouldThrowDomainException()
    {
        var futureDate = DateTime.UtcNow.AddDays(1);
        var action = () => new Income("user-123", 100m, "Freelance", futureDate);

        action.Should().Throw<ArgumentException>()
            .WithMessage("Date cannot be in the future.");
    }
}