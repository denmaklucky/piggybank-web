using System.ComponentModel;

namespace PiggyBank.Common.Enums
{
    public enum CategoryType
    {
        [Description("Не определёно")]
        Undefined = 0,

        [Description("Доход")]
        Income,

        [Description("Расход")]
        Expense,
    }
}
