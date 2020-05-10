using Microsoft.AspNetCore.Components;
using PiggyBank.Common.Models.Dto;
using PiggyBank.WebSite.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.ViewModels.Accounts
{
    public class AccountsViewModel : ComponentBase
    {
        private const string DisplayNone = "display:none;";
        private const string DisplayBlock = "display:block;";

        [Inject]
        public IAccountModel AccountModel { get; set; }

        public IList<AccountInfoDto> Accounts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Accounts = await AccountModel.GetAccounts();
        }

        public AccountInfoDto SelectedAccount { get; set; }

        public bool ShowEditModal { get; set; } = false;

        public string ArchivedAccountsStyle { get; set; } = DisplayNone;

        public void OnShow(AccountInfoDto selectedAccount)
        {
            SelectedAccount = selectedAccount;
            ShowEditModal = true;
        }

        public void ShowArchived(bool show)
            => ArchivedAccountsStyle = show
                                     ? DisplayBlock
                                     : DisplayNone;

        public void OnSaved(AccountInfoDto savedAccount)
        {
            ShowEditModal = false;
        }

        public void OnHided()
        {
            ShowEditModal = false;
        }
    }
}
