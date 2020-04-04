using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PiggyBank.Common.Interfaces;
using PiggyBank.Common.Models.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.ViewModels.Accounts
{
    public class AccountSectionViewModel : ViewModelBase<AccountInfoDto[]>
    {
        private const string DefaultClass = "col-auto";
        public AccountSectionViewModel()
            => Class = DefaultClass;

        [Inject]
        public IAccountService AccountService { get; set; }

        public string AccountViewClass { get; set; } = "d-none";

        public AccountInfoDto SelectedItem { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Model = await AccountService.GetAccounts();
        }

        public void OnCardClick(int accountId, MouseEventArgs args)
            => OpenAccountView(accountId);

        public void OnCloseAccountView()
        {
            AccountViewClass = "d-none";
            Class = DefaultClass;
        }

        public void OnAddNewAccount()
            => OpenAccountView();

        private void OpenAccountView(int accountId = 0)
        {
            SelectedItem = Model.FirstOrDefault(a => a.Id == accountId) ?? new AccountInfoDto();
            AccountViewClass = "d-block col-3 color";
            Class = "col-9";
        }
    }
}
