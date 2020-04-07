using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Dto;
using PiggyBank.Domain.Handler.Operations;
using PiggyBank.Domain.Queries.Operations;
using System;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Services
{
    public partial class PiggyService : IOperationService
    {
        public Task AddBudgetOperation(AddBudgetOperationCommand command)
            => _handlerDispatcher.Invoke<AddBudgetOperationHandler, AddBudgetOperationCommand>(command);

        public Task AddTransferOperation(AddTransferOperationCommand command)
            => _handlerDispatcher.Invoke<AddTransferOperationHandler, AddTransferOperationCommand>(command);

        public Task<OperationDto> GetOperation(int id)
            => _queryDispatcher.Invoke<GetOperationByIdQuery, OperationDto>(id);

        public Task<OperationDto[]> GetOperations()
            => _queryDispatcher.Invoke<GetOperationsQuery, OperationDto[]>();

        public Task UpdateCategory(UpdateOperationCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
