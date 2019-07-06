using piggybank.dal.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace piggybank.dal.Models
{
    public class Transaction : EntityBase, IBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public int AccountId { get; set; }

        public string Comment { get; set; }

        public TransactionType Type { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
