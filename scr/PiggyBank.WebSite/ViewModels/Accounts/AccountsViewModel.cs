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

        public string AccountViewClass { get; set; } = "d-none";

        public int AccountViewId { get; set; }

        public string Class { get; set; } = "col-auto";

        protected override async Task OnInitializedAsync()
        {
            Accounts = await AccountService.GetAccounts();
        }

        public void OnCardClick(int accountId, MouseEventArgs args)
        {
            //NavigationManager.NavigateTo($"accounts/{accountId}");
            AccountViewId = accountId;
            AccountViewClass = "d-block col-3 color";
            Class = "col-9";
        }

        public void OnAddNewAccount()
        {
            NavigationManager.NavigateTo($"accounts/{default(int)}");
        }
    }
}
