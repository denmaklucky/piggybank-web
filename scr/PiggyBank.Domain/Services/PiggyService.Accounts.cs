using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Enums;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Generic;
using PiggyBank.Common.Models.ReturnModels;
using System;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Services
{
    public partial class PiggyService : IAccountService
    {
        public Task AddAccount(AddAccountCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<AccountDto[]> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public Task<GenericGroup<AccountType, AccountDto>[]> GetAccountsGroupByType()
        {
            throw new NotImplementedException();
        }

    }
}
