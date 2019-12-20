using Microsoft.AspNetCore.Components;
using PiggyBank.Common.Enums;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.ReturnModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.ViewModels.Accounts
{
    public class AccountsViewModel : ComponentBase
    {
        [Inject]
        public IPiggyService PiggyService { get; set; }

        public AccountDto[] Accounts { get; set; }

        public Dictionary<AccountType, AccountDto[]> GroupAccounts { get; private set; }

        protected override async Task OnInitializedAsync()
        {
            var accounts = await PiggyService.GetAccounts();
            GroupAccounts = accounts.ToDictionary<AccountDto[], AccountType>();
        }
    }
}
