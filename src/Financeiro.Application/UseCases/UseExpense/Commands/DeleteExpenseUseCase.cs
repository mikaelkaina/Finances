using Financeiro.Application.DTOs.Expense;
using Financeiro.Application.Interfaces;
using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Exceptions;

namespace Financeiro.Application.UseCases.UseExpense.Commands;

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

        if (expense is null)
            throw new DomainException("Despesa não encontrada.");

        if (expense.UserId != input.UserId)
            throw new DomainException("Usuário não autorizado a deletar esta despesa.");

        _repository.Remove(expense);
        await _unitOfWork.SaveChangesAsync();
    }
}
