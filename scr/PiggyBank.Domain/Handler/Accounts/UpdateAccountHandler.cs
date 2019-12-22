using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Model;
using PiggyBank.Model.Models;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Handler.Accounts
{
    public class UpdateAccountHandler : BaseHandler<UpdateAccountCommand>
    {
        public UpdateAccountHandler(PiggyContext context, UpdateAccountCommand command)
            : base(context, command) { }

        public override async Task Invoke()
        {
            var account = await GetRepository<Account>()
                .FirstOrDefaultAsync(a => a.Id == Command.Id);

            if (account == null) return;

            account.IsArchived = Command.IsArchived;
            account.IsDeleted = Command.IsDeleted;
            account.Title = Command.Title;
            account.Type = Command.Type;
            account.Balance = Command.Balance;

            GetRepository<Account>().Update(account);
        }
    }
}
