using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.ReturnModels;
using PiggyBank.Domain.Handler.Accounts;
using PiggyBank.Domain.Infrastructure;
using PiggyBank.Domain.Queries.Accounts;
using PiggyBank.Model;

namespace PiggyBank.Domain
{
    public class PiggyService : IPiggyService
    {
        private readonly HandlerDispatcher _handlerDispatcher;
        private readonly QueryDispatcher _queryDispatcher;

        public PiggyService()
        {
            var builder = new DbContextOptionsBuilder<PiggyContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Piggy;Trusted_Connection=True;MultipleActiveResultSets=true");
            var context =  new PiggyContext(builder.Options);

            context.Database.Migrate();

            _handlerDispatcher = new HandlerDispatcher(context);
            _queryDispatcher = new QueryDispatcher(context);
        }

        public Task AddAccount(AddAccountCommand command)
            => _handlerDispatcher.Invoke<AddAccountHandler, AddAccountCommand>(command);

        public Task<AccountDto[]> GetAccounts()
            => _queryDispatcher.Invoke<GetAccountsQuery, AccountDto[]>();
    }
}
