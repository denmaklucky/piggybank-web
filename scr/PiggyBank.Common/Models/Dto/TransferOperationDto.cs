namespace PiggyBank.Common.Models.Dto
{
    public class TransferOperationDto
    {
        public int From { get; set; }

        public int To { get; set; }

        public decimal Amount { get; set; }
    }
}
