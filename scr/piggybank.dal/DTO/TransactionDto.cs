using piggybank.common.Enums;
using piggybank.dal.Models;
using System;

namespace piggybank.dal.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int AccountId { get; set; }

        public decimal Amount { get; set; }

        public string Comment { get; set; }

        public TransactionType Type { get; set; }

        public Category Category { get; set; }

        public Account Account { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
