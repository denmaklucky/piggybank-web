using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.ReturnModels;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.ViewModels.Accounts
{
    public class AccountsViewModel : ComponentBase
    {
        [Inject]
        public IAccountService AccountService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public AccountInfoDto[] Accounts { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Accounts = await AccountService.GetAccounts();
        }

        public void OnCardClick(int accountId, MouseEventArgs args)
        {
            NavigationManager.NavigateTo($"accounts/{accountId}");
        }

        public void OnAddNewAccount()
        {
            NavigationManager.NavigateTo($"accounts/{default(int)}");
        }
    }
}
