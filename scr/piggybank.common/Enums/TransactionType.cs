using System.ComponentModel;

namespace PiggyBank.Common.Enums
{
    public enum TransactionType
    {
        [Description("Не определёно")]
        Undefined = 0,

        [Description("Доход")]
        Income = 1,

        [Description("Расход")]
        Expense = 2,

        [Description("Перевод")]
        Transfer = 3,

        [Description("Корректировка остатка")]
        Correction = 4,

        [Description("Долг")]
        Debt = 5,

        [Description("Планируеммая транзакция")]
        Plan = 6
    }
}
