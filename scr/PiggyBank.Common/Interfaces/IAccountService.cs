﻿using PiggyBank.Common.Commands.Accounts;
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
        /// <param name="command"></param>
        /// <returns></returns>
        Task AddAccount(AddAccountCommand command);

        /// <summary>
        /// Get accounts
        /// </summary>
        /// <returns></returns>
        Task<AccountInfoDto[]> GetAccounts();

        /// <summary>
        /// Get accounts group by type
        /// </summary>
        /// <returns></returns>
        Task<GenericGroup<AccountType, AccountInfoDto>[]> GetAccountsGroupByType();

        /// <summary>
        /// Get account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<AccountDto> GetAccount(int id);
    }
}
