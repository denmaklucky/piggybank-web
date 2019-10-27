using System.ComponentModel;

namespace PiggyBank.Common.Enums
{
    public enum AccountType
    {
        [Description("Не определёно")]
        Undefined = 0,

        [Description("Наличные")]
        Cash,

        [Description("Банковская карта")]
        Card,

        [Description("Банковский счет")]
        BankAccount,

        [Description("Депозит")]
        Deposit
    }
}
