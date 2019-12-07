using System;
using System.Linq;
using System.Threading.Tasks;
using PiggyBank.Common.Commands.Accounts;
using PiggyBank.Common.Enums;
using PiggyBank.Common.Interfaces;

namespace PiggyBank.WebSite.Data
{
    public class WeatherForecastService
    {
        private readonly IPiggyService _service;
        public WeatherForecastService(IPiggyService service)
        {
            _service = service;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        public async Task AddCount()
        {
            var addCommand = new AddAccountCommand
            {
                Balance = 12M,
                Currency = "RU",
                Title = "Test Account",
                Type = AccountType.Card
            };

            await _service.AddAccount(addCommand);
        }
    }
}
