namespace PiggyBank.Model.Models
{
    public class TransferOperation : Operation
    {
        public int From { get; set; }

        public int To { get; set; }
    }
}
