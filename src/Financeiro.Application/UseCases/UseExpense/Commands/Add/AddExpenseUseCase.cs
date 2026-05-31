
using Financeiro.Domain.Entities;
using Financeiro.Domain.Interfaces;
using Financeiro.Domain.Interfaces.Repositories;

namespace Financeiro.Application.UseCases.UseExpense.Commands.Add;

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
        
        _repository.Add(expense);
        await _unitOfWork.SaveChangesAsync();
    }
}
