using Financeiro.Application.DTOs.Income;
using Financeiro.Application.Interfaces;
using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Exceptions;

namespace Financeiro.Application.UseCases.UseIncome;

public class DeleteIncomeUseCase
{
    private readonly IIncomeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteIncomeUseCase(IIncomeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(DeleteIncomeInput input)
    {
        var income = await _repository.GetByIdAsync(input.IncomeId);

        if (income is null)
            throw new DomainException("Receita não encontrada.");

        if (income.UserId != input.UserId)
            throw new DomainException("Você não tem permissão para apagar esta receita.");

        _repository.Remove(income);
        await _unitOfWork.SaveChangesAsync();
    }
}
