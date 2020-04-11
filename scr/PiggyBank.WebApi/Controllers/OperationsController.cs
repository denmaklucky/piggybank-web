using Microsoft.AspNetCore.Mvc;
using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Dto;
using System;
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
            => _service.GetOperations(token);

        [HttpPost, Route("budget")]
        public async Task<IActionResult> PostBudget(BudgetOperationDto request, CancellationToken token)
        {
            var command = new AddBudgetOperationCommand
            {
                AccountId = request.AccountId,
                Amount = request.Amount ?? decimal.Zero,
                CategoryId = request.CategoryId,
                Comment = request.Comment
            };

            await _service.AddBudgetOperation(command, token);

            return Ok();
        }

        [HttpPost, Route("transfer")]
        public async Task<IActionResult> PostTransfer(TransferOperationDto request, CancellationToken token)
        {
            var command = new AddTransferOperationCommand
            {
                Amount = request.Amount ?? decimal.Zero,
                From = request.From,
                To = request.To,
                Comment = request.Comment
            };

            await _service.AddTransferOperation(command, token);

            return Ok();
        }

        [HttpPost, Route("plan")]
        public async Task<IActionResult> PostPlan(PlanOperationDto request, CancellationToken token)
        {
            var command = new AddPlanOperationCommand
            {
                Amount = request.Amount ?? decimal.Zero,
                CategoryId = request.CategoryId,
                Comment = request.Comment,
                PlanDate = request.PlanDate ?? DateTime.MinValue,
                AccountId = request.AccountId
            };

            await _service.AddPlanOperation(command, token);

            return Ok();
        }

        [HttpPost, Route("plan/{operationId}/apply")]
        public async Task<IActionResult> ApplyPlanOperation(int operationId, CancellationToken token)
        {
            await _service.ApplyPlanOperation(operationId, token);
            return Ok();
        }
    }
}
