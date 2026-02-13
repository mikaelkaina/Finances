using Financeiro.Application.DTOs.Expense;
using Financeiro.Application.Interfaces;
using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Exceptions;

namespace Financeiro.Application.UseCases.UseExpense;

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

        if (expense is null)
            throw new DomainException("Despesa não encontrada.");

        if (expense.UserId != input.UserId)
            throw new DomainException("Você não tem permissão para editar esta receita.");

        expense.UpdateExpense(input.Amount, input.Description, input.Date);
        await _unitOfWork.SaveChangesAsync();

    }
}
