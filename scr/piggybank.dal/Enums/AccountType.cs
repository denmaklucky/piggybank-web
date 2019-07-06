using System.ComponentModel;

namespace piggybank.dal.Enums
{
    public enum AccountType
    {
        [Description("Не определёно")]
        Undefined = 0,

        [Description("Наличные")]
        Cash = 1,

        [Description("Банковская карта")]
        Card = 2,

        [Description("Банковский счет")]
        BankAccount = 3,

        [Description("Депозит")]
        Deposit = 4,

        [Description("Кредит")]
        Credit = 5
    }
}
