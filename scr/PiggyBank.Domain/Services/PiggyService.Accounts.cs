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

        public Task DeleteAccount(int id)
            => _handlerDispatcher.Invoke<DeleteAccountHandler, int>(id);

        public Task<AccountDto> GetAccount(int accountId)
            => _queryDispatcher.Invoke<GetAccountByIdQuery, AccountDto>(accountId);

        public Task<AccountInfoDto[]> GetAccounts()
            => _queryDispatcher.Invoke<GetAccountsQuery, AccountInfoDto[]>();

        public Task<GenericGroup<AccountType, AccountInfoDto>[]> GetAccountsGroupByType()
            => _queryDispatcher.Invoke<GetAccountsGroupByTypeQuery, GenericGroup<AccountType, AccountInfoDto>[]>();

        public Task UpdateAccount(UpdateAccountCommand command)
            => _handlerDispatcher.Invoke<UpdateAccountHandler, UpdateAccountCommand>(command);
    }
}
