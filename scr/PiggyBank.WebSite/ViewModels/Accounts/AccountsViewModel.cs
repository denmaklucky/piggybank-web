using Microsoft.AspNetCore.Components;
using PiggyBank.Common.Models.Dto;
using PiggyBank.WebSite.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.ViewModels.Accounts
{
    public class AccountsViewModel : ComponentBase
    {
        [Inject]
        public IAccountModel AccountModel { get; set; }

        public IList<AccountInfoDto> Accounts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Accounts = await AccountModel.GetAccounts();
        }
    }
}
