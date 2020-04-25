using PiggyBank.Common.Models.Dto;
using PiggyBank.WebSite.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace PiggyBank.WebSite.Models
{
    public class AccountModel : IAccountModel
    {
        private readonly HttpClient _httpClient;

        public AccountModel(IHttpClientFactory httpFactory)
            => _httpClient = httpFactory.CreateClient();

        public Task AddAccount(AccountDto account)
        {
            throw new System.NotImplementedException();
        }

        public Task<AccountInfoDto[]> GetAccounts()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAccount(AccountDto account)
        {
            throw new System.NotImplementedException();
        }
    }
}
