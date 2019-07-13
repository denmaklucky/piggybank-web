using System.ComponentModel;

namespace piggybank.common.Enums
{
    public enum CategoryType
    {
        [Description("Не определёно")]
        Undefined = 0,

        [Description("Доход")]
        Income = 1,

        [Description("Расход")]
        Expense = 2,
    }
}
