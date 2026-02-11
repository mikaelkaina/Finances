using Financeiro.Application.DTOs.Expense;
using Financeiro.Application.Interfaces;
using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Entities;

namespace Financeiro.Application.UseCases.UseExpense;

public class AddExpenseUseCase
{
    private readonly IExpenseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public AddExpenseUseCase(IExpenseRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(AddExpenseInput input)
    {
        var expense = new Expense(
            input.UserId,
            input.Amount,
            input.Description,
            input.Date
        );

        await _repository.AddAsync(expense);
        await _unitOfWork.SaveChangesAsync();
    }
}
