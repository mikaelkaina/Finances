using Financeiro.Domain.Interfaces;
using Financeiro.Domain.Interfaces.Repositories;
using Menso.Tools.Exceptions;

namespace Financeiro.Application.UseCases.UseExpense.Commands.Delete;

public class DeleteExpenseUseCase
{
    private readonly IExpenseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteExpenseUseCase(IExpenseRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(DeleteExpenseInput input)
    {
        var expense = await _repository.GetByIdAsync(input.ExpenseId);
        Throw.When.Null(expense, ResourceExpense.ExpenseNotFound);
        
        _repository.Remove(expense);
        await _unitOfWork.SaveChangesAsync();
    }
}
