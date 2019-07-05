using piggybank.dal.Enums;
using System.ComponentModel.DataAnnotations;

namespace piggybank.dal.Models
{
    public class Account : EntityBase, IBaseModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public AccountType Type { get; set; }
        
        public string Currency { get; set; }

        public decimal Balance { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsArchived { get; set; }
    }
}
