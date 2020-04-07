using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Enums;
using PiggyBank.Model;
using PiggyBank.Model.Models.Entities;
using System;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Handler.Operations
{
    public class ApplyPlanOperationHandler : BaseHandler<int>
    {
        public ApplyPlanOperationHandler(PiggyContext context, int command)
            : base(context, command) { }

        public override async Task Invoke()
        {
            var budget = GetRepository<BudgetOperation>();
            var plan = GetRepository<PlanOperation>();

            var operation = await plan.FirstOrDefaultAsync(p => p.Id == Command)
            ?? throw new ArgumentException("Can't found plan operaton");

            operation.IsDeleted = true;
            plan.Update(operation);

            budget.Add(new BudgetOperation 
            {
                AccountId = operation.AccountId,
                Amount = operation.Amount,
                CategoryId = operation.CategoryId,
                Comment = operation.Comment,
                CreatedBy = operation.CreatedBy,
                CreatedOn = operation.CreatedOn,
                Type = OperationType.Budget
            });
        }
    }
}
