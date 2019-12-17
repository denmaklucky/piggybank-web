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

        public PiggyService(ServiceSettings settings)
        {
            var context = InitializationContext(settings.ConnectionString);
            context.Database.Migrate();

            _handlerDispatcher = new HandlerDispatcher(context);
            _queryDispatcher = new QueryDispatcher(context);
        }

        public Task AddAccount(AddAccountCommand command)
            => _handlerDispatcher.Invoke<AddAccountHandler, AddAccountCommand>(command);

        public Task<AccountDto[]> GetAccounts()
            => _queryDispatcher.Invoke<GetAccountsQuery, AccountDto[]>();

        private PiggyContext InitializationContext(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<PiggyContext>();
            builder.UseSqlServer(connectionString);
            return new PiggyContext(builder.Options);
        }
    }
}
