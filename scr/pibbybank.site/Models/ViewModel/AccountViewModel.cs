using piggybank.common.Enums;
using System.ComponentModel.DataAnnotations;

namespace piggybank.site.Models.ViewModel
{
    public class AccountViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public AccountType Type { get; set; }

        [Required]
        public string Currency { get; set; }

        public decimal Balance { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsArchived { get; set; }
    }
}
