using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Enums;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Generic;
using PiggyBank.Common.Models.ReturnModels;
using PiggyBank.Domain.Handler.Accounts;
using PiggyBank.Domain.Queries.Accounts;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Services
{
    public partial class PiggyService : IAccountService
    {
        public Task AddAccount(AddAccountCommand command)
             => _handlerDispatcher.Invoke<AddAccountHandler, AddAccountCommand>(command);

        public Task<AccountDto[]> GetAccounts()
            => _queryDispatcher.Invoke<GetAccountsQuery, AccountDto[]>();

        public Task<GenericGroup<AccountType, AccountDto>[]> GetAccountsGroupByType()
            => _queryDispatcher.Invoke<GetAccountsGroupByTypeQuery, GenericGroup<AccountType, AccountDto>[]>();

    }
}
