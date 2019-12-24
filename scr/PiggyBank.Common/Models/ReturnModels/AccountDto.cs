using PiggyBank.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Common.Models.ReturnModels
{
    public class AccountDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2, ErrorMessage ="Title can't be empty")]
        public string Title { get; set; }

        public AccountType Type { get; set; }

        public string Currency { get; set; }

        public decimal Balance { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsArchived { get; set; }
    }
}
