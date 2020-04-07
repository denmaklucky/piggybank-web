using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Models.Dto;
using System.Threading.Tasks;

namespace PiggyBank.Common.Interfaces
{
    public interface IOperationService
    {
        /// <summary>
        /// Add a new budget operation
        /// </summary>
        Task AddBudgetOperation(AddBudgetOperationCommand command);

        /// <summary>
        /// Add a new transfer operation
        /// </summary>
        Task AddTransferOperation(AddTransferOperationCommand command);

        /// <summary>
        /// Add a new plan operation
        /// </summary>
        Task AddPlanOperation(AddPlanOperationCommand command);

        /// <summary>
        /// Apply exists plan operation
        /// </summary>
        Task ApplyPlanOperation(int planOperationId);

        /// <summary>
        /// Get operations
        /// </summary>
        Task<OperationDto[]> GetOperations();

        /// <summary>
        /// Get operation by id
        /// </summary>
        Task<OperationDto> GetOperation(int id);

        /// <summary>
        /// Update exists entity
        /// </summary>
        Task UpdateCategory(UpdateOperationCommand command);
    }
}
