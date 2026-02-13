using Financeiro.Application.DTOs.Income;
using Financeiro.Application.Interfaces;
using Financeiro.Application.Interfaces.Repositories;
using Financeiro.Domain.Exceptions;

namespace Financeiro.Application.UseCases.UseIncome;

public class UpdateIncomeUseCase
{
    private readonly IIncomeRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateIncomeUseCase(IIncomeRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task ExecuteAsync(UpdateIncomeInput input)
    {
        var income = await _repository.GetByIdAsync(input.IncomeId);

        if (income is null)
            throw new DomainException("Receita não encontrada.");

        if(income.UserId != input.UserId)
            throw new DomainException("Você não tem permissão para editar esta receita.");

        income.UpdateIncome(input.Amount, input.Description, input.Date);

        await _unitOfWork.SaveChangesAsync();
    }
}
