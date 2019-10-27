using PiggyBank.Common.Enums;
using PiggyBank.Model.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiggyBank.Model.Models
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

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
