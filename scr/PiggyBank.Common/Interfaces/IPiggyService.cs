using System.Collections.Generic;
using System.Threading.Tasks;
using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Enums;
using PiggyBank.Common.Models.ReturnModels;

namespace PiggyBank.Common.Interfaces
{
    public interface IPiggyService
    {
        Task AddAccount(AddAccountCommand command);

        Task<AccountDto[]> GetAccounts();

        Task<Dictionary<AccountType, AccountDto[]>> GetAccountsGroupByType();
    }
}
