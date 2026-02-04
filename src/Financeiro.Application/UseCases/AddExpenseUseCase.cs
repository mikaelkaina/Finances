using Financeiro.Application.DTOs.Expense;
using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Entities;

namespace Financeiro.Application.UseCases;

public class AddExpenseUseCase
{
    private readonly IExpenseRepository _repository;

    public AddExpenseUseCase(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(AddExpenseInput input)
    {
        var expense = new Expense(
            input.UserId,
            input.Amount,
            input.Description,
            input.Date);

        await _repository.AddAsync(expense);
    }
}
