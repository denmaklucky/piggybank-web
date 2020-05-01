using PiggyBank.Common.Enums;
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

        public async Task<AccountInfoDto[]> GetAccounts()
        {
            await Task.Delay(2000);
            return new[] 
            {
                new AccountInfoDto
                {
                    Id = 1,
                    Balance = 100,
                    Currency = "RUB",
                    Title = "Rocket",
                    Type = AccountType.Card
                }, 
                new AccountInfoDto
                {
                    Id = 2,
                    Balance = 200,
                    Currency = "RUB",
                    Title = "Tinkoff",
                    Type = AccountType.Card
                },
                new AccountInfoDto
                {
                    Id = 3,
                    Balance = 400,
                    Currency = "RUB",
                    Title = "Home money",
                    Type = AccountType.Cash
                }
            };
        }

        public Task UpdateAccount(AccountDto account)
        {
            throw new System.NotImplementedException();
        }
    }
}
