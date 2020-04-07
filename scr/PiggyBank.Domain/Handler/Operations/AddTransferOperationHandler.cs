using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Commands.Operations;
using PiggyBank.Common.Enums;
using PiggyBank.Model;
using PiggyBank.Model.Models.Entities;
using System;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Handler.Operations
{
    public class AddTransferOperationHandler : BaseHandler<AddTransferOperationCommand>
    {
        public AddTransferOperationHandler(PiggyContext context, AddTransferOperationCommand command)
            : base(context, command) { }

        public override async Task Invoke()
        {
            var accountRepository = GetRepository<Account>();
            var fromAccount = await accountRepository.FirstOrDefaultAsync(a => a.Id == Command.From && !a.IsDeleted)
                ?? throw new ArgumentException($"Can't found account by {Command.From}");
            var toAccount = await accountRepository.FirstOrDefaultAsync(a => a.Id == Command.To && !a.IsDeleted)
                ?? throw new ArgumentException($"Can't found account by {Command.To}");

            var operation = new TransferOperation
            {
                Amount = Command.Amount,
                Type = OperationType.Transfer
            };

            fromAccount.ChangeBalance(-Command.Amount);
            toAccount.ChangeBalance(Command.Amount);

            accountRepository.UpdateRange(new[] { fromAccount, toAccount });

            GetRepository<TransferOperation>().Add(operation);
        }
    }
}
