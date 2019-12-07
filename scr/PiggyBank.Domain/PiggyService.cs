using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Interfaces;
using PiggyBank.Domain.Handler.Accounts;
using PiggyBank.Domain.Infrastructure;
using PiggyBank.Model;

namespace PiggyBank.Domain
{
    public class PiggyService : IPiggyService
    {
        private readonly HandlerDispatcher _handlerDispatcher;

        public PiggyService()
        {
            var builder = new DbContextOptionsBuilder<PiggyContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Piggy;Trusted_Connection=True;MultipleActiveResultSets=true");
            var context =  new PiggyContext(builder.Options);

            context.Database.Migrate();

            _handlerDispatcher = new HandlerDispatcher(context);
        }

        public Task AddAccount(AddAccountCommand command)
            => _handlerDispatcher.Invoke<AddAccountHandler, AddAccountCommand>(command);
    }
}
