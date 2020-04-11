using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Common.Models.Dto
{
    public class BudgetOperationDto
    {
        [Required]
        public int AccountId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string Comment { get; set; }
    }
}
