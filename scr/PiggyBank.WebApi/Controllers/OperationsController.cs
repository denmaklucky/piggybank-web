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

        [HttpPost, Route("budget")]
        public async Task<IActionResult> PostBudget(OperationDto request, CancellationToken token)
        {
            var command = new AddBudgetOperationCommand
            {
                AccountId = request.AccountId,
                Amount = request.Amount,
                CategoryId = request.CategoryId,
                Comment = request.Comment,
                Type = request.Type
            };

            await _service.AddBudgetOperation(command);

            return Ok();
        }

        [HttpPost, Route("transfer")]
        public async Task<IActionResult> PostTransfer(TransferOperationDto request, CancellationToken token)
        {
            var command = new AddTransferOperationCommand
            {
                Amount = request.Amount,
                From = request.From,
                To = request.To
            };

            await _service.AddTransferOperation(command);

            return Ok();
        }

        [HttpPost, Route("plan")]
        public async Task<IActionResult> PostPlan(PlanOperationDto request, CancellationToken token)
        {
            var command = new AddPlanOperationCommand
            {
                Amount = request.Amount,
                CategoryId = request.CategoryId,
                Comment = request.Comment,
                Type = request.Type,
                PlanDate = request.PlanDate,
                AccountId = request.AccountId
            };

            await _service.AddPlanOperation(command);

            return Ok();
        }

        [HttpPost, Route("plan/{operationId}/apply")]
        public async Task<IActionResult> ApplyPlanOperation(int operationId, CancellationToken token)
        {
            await _service.ApplyPlanOperation(operationId);
            return Ok();
        }
    }
}
