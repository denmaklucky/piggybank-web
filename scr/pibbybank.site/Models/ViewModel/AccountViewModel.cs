using piggybank.common.Enums;
using System.ComponentModel;
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

        [DisplayName("Deleted")]
        public bool IsDeleted { get; set; }

        [DisplayName("Archived")]

        public bool IsArchived { get; set; }
    }
}
