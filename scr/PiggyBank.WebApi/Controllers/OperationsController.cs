using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Dto;
using PiggyBank.WebApi.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PiggyBank.WebApi.Controllers
{
    [Authorize]
    [ApiController, Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _service;
        public OperationsController(IOperationService service)
            => _service = service;

        [HttpGet]
        public Task<OperationDto[]> Get(CancellationToken token)
            => _service.GetOperations(token);

        #region Budget

        [HttpPost, Route("budget")]
        public async Task<IActionResult> PostBudget(BudgetOperationDto request, CancellationToken token)
        {
            var command = new AddBudgetOperationCommand
            {
                AccountId = request.AccountId,
                Amount = request.Amount.GetValueOrDefault(),
                CategoryId = request.CategoryId,
                Comment = request.Comment,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = User.GetUserId()
            };

            await _service.AddBudgetOperation(command, token);

            return Ok();
        }

        [HttpDelete, Route("budget/{operationId}/delete")]
        public async Task<IActionResult> DelteBudgetOperation(int operationId, CancellationToken token)
        {
            await _service.DeleteBudgetOperation(operationId, token);
            return Ok();
        }

        #endregion

        #region Transfer

        [HttpPost, Route("transfer")]
        public async Task<IActionResult> PostTransfer(TransferOperationDto request, CancellationToken token)
        {
            var command = new AddTransferOperationCommand
            {
                Amount = request.Amount.GetValueOrDefault(),
                From = request.From,
                To = request.To,
                Comment = request.Comment,
                CreatedOn = DateTime.UtcNow,
                CreatedBy = User.GetUserId()
            };

            await _service.AddTransferOperation(command, token);

            return Ok();
        }

        [HttpDelete, Route("transfer/{operationId}/delete")]
        public async Task<IActionResult> DelteTransferOperation(int operationId, CancellationToken token)
        {
            await _service.DeleteTransferOperation(operationId, token);
            return Ok();
        }

        #endregion

        #region Plan

        [HttpPost, Route("plan")]
        public async Task<IActionResult> PostPlan(PlanOperationDto request, CancellationToken token)
        {
            var command = new AddPlanOperationCommand
            {
                Amount = request.Amount.GetValueOrDefault(),
                CategoryId = request.CategoryId,
                Comment = request.Comment,
                PlanDate = request.PlanDate.GetValueOrDefault(),
                AccountId = request.AccountId,
                CreatedBy = User.GetUserId(),
                CreatedOn = DateTime.UtcNow
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

        [HttpDelete, Route("plan/{operationId}/delete")]
        public async Task<IActionResult> DeltePlanOperation(int operationId, CancellationToken token)
        {
            await _service.DeletePlanOperation(operationId, token);
            return Ok();
        }

        #endregion
    }
}
