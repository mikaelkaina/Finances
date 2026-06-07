using Financeiro.Domain.Interfaces;
using Financeiro.Domain.Interfaces.Repositories;
using Menso.Tools.Exceptions;

namespace Financeiro.Application.UseCases.UseExpense.Commands.Update;

public class UpdateExpenseUseCase
{
    private readonly IExpenseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateExpenseUseCase(IExpenseRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(UpdateExpenseInput input)
    {
        var expense = await _repository.GetByIdAsync(input.ExpenseId);
        Throw.When.Null(expense, ResourceExpense.ExpenseNotFound);
        
        expense.UpdateExpense(input.Amount, input.Description, input.Date);
        await _unitOfWork.SaveChangesAsync();

    }
}
