using Microsoft.AspNetCore.Components;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.ReturnModels;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.ViewModels.Accounts
{
    public class AccountViewModel : ComponentBase
    {
        [Parameter]
        public int AccountId { get; set; }

        [Inject]
        public IAccountService AccountService { get; set; }

        public AccountDto Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Model = await AccountService.GetAccount(AccountId);
        }
    }
}
