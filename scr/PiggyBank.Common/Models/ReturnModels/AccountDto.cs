namespace PiggyBank.Common.Models.ReturnModels
{
    public class AccountDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Currency { get; set; }

        public decimal Balance { get; set; }
    }
}
