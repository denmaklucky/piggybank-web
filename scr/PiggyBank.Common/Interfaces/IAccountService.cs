using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Enums;
using PiggyBank.Common.Models.Generic;
using PiggyBank.Common.Models.ReturnModels;
using System.Threading.Tasks;

namespace PiggyBank.Common.Interfaces
{
    public interface IAccountService
    {
        Task AddAccount(AddAccountCommand command);

        Task<AccountDto[]> GetAccounts();

        Task<GenericGroup<AccountType, AccountDto>[]> GetAccountsGroupByType();
    }
}
