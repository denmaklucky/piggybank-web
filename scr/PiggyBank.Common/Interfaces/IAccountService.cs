using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Enums;
using PiggyBank.Common.Models.Generic;
using PiggyBank.Common.Models.ReturnModels;
using System.Threading.Tasks;

namespace PiggyBank.Common.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Add a new account
        /// </summary>
        Task AddAccount(AddAccountCommand command);

        /// <summary>
        /// Get accounts
        /// </summary>
        Task<AccountInfoDto[]> GetAccounts();

        /// <summary>
        /// Get accounts group by type
        /// </summary>
        Task<GenericGroup<AccountType, AccountInfoDto>[]> GetAccountsGroupByType();

        /// <summary>
        /// Get account by id
        /// </summary>
        Task<AccountDto> GetAccount(int id);

        /// <summary>
        /// Update exists entity
        /// </summary>
        Task UpdateAccount(UpdateAccountCommand command);

        /// <summary>
        /// Delete exists entiry
        /// </summary>
        Task DeleteAccount(int id);
    }
}
