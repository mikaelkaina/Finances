using Financeiro.Domain.Interfaces;
using Financeiro.Domain.Exceptions;
using Financeiro.Domain.Interfaces.Repositories;

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

        if (expense is null)
            throw new DomainException("Despesa não encontrada.");

        if (expense.UserId != input.UserId)
            throw new DomainException("Usuário não autorizado a deletar esta despesa.");

        _repository.Remove(expense);
        await _unitOfWork.SaveChangesAsync();
    }
}
