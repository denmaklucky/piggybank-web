using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Enums;
using PiggyBank.Model;
using PiggyBank.Model.Models.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Handler.Operations
{
    public class AddPlanOperationHandler : BaseHandler<AddPlanOperationCommand>
    {
        public AddPlanOperationHandler(PiggyContext context, AddPlanOperationCommand command)
            : base(context, command) { }

        public override async Task Invoke(CancellationToken token)
        {
            var accountRepository = GetRepository<Account>();

            var account = await accountRepository.FirstOrDefaultAsync(a => a.Id == Command.AccountId && !a.IsDeleted)
                ?? throw new ArgumentException($"Can't found account by {Command.AccountId}");

            var category = await GetRepository<Category>().FirstOrDefaultAsync(c => c.Id == Command.CategoryId && !c.IsDeleted)
                ?? throw new ArgumentException($"Can't found category by {Command.CategoryId}");

            var operation = new PlanOperation
            {
                Amount = Command.Amount,
                Type = OperationType.Plan,
                Comment = Command.Comment,
                AccountId = Command.AccountId,
                CategoryId = Command.CategoryId,
                PlanDate = Command.PlanDate,
                CreatedOn = DateTime.UtcNow
            };

            await GetRepository<PlanOperation>().AddAsync(operation, token);
        }
    }
}
