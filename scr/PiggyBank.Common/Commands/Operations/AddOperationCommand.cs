using PiggyBank.Common.Enums;

namespace PiggyBank.Common.Commands.Operations
{
    public class AddOperationCommand
    {
        public int CategoryId { get; set; }

        public decimal Amount { get; set; }

        public int AccountId { get; set; }

        public string Comment { get; set; }

        public OperationType Type { get; set; }
    }
}
