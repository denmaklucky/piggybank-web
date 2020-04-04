using Microsoft.AspNetCore.Mvc;
using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace PiggyBank.WebApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _service;
        public OperationsController(IOperationService service)
            => _service = service;

        [HttpGet]
        public Task<OperationDto[]> Get(CancellationToken token)
            => _service.GetOperations();

        [HttpGet, Route("{operationId}")]
        public Task<OperationDto> GetById(int operationId, CancellationToken token)
            => _service.GetOperation(operationId);

        [HttpPost]
        public async Task<IActionResult> Post(OperationDto request, CancellationToken token)
        {
            var command = new AddOperationCommand
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CategoryId = request.CategoryId,
                Comment = request.Comment,
                Type = request.Type
            };

            switch (command.Type)
            {
                case Common.Enums.OperationType.Income:
                    await _service.AddIncomeOperation(command);
                    break;
                case Common.Enums.OperationType.Expense:
                    await _service.AddExpenseOperation(command);
                    break;
            }

            return Ok();
        }
    }
}
