using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Commands.Operations;
using PiggyBank.Model;
using PiggyBank.Model.Models;
using System;
using System.Threading.Tasks;
using OperatonModel = PiggyBank.Model.Models.Operation;

namespace PiggyBank.Domain.Handler.Operations
{
    public class AddExpenseOperationHandler : BaseHandler<AddOperationCommand>
    {
        public AddExpenseOperationHandler(PiggyContext context, AddOperationCommand command)
            : base(context, command) { }

        public override async Task Invoke()
        {
            var accountRepository = GetRepository<Account>();
            var account = await accountRepository.FirstOrDefaultAsync(a => a.Id == Command.AccountId && !a.IsDeleted)
                ?? throw new ArgumentException($"Can't found account by {Command.AccountId}");

            var category = await GetRepository<Category>().FirstOrDefaultAsync(c => c.Id == Command.CategoryId && !c.IsDeleted)
                ?? throw new ArgumentException($"Can't found category by {Command.CategoryId}");

            var operation = new OperatonModel
            {
                Amount = Command.Amount,
                Type = Command.Type,
                Comment = Command.Comment,
                AccountId = Command.AccountId,
                CategoryId = Command.CategoryId
            };

            account.Balance -= operation.Amount;

            accountRepository.Update(account);

            GetRepository<OperatonModel>().Add(operation);
        }
    }
}
