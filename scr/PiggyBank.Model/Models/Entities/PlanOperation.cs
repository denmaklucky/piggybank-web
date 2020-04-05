﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiggyBank.Model.Models.Entities
{
    public class PlanOperation : Operation
    {
        [Required]
        public DateTime PlanDate { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public int AccountId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(AccountId))]
        public virtual Account Account { get; set; }
    }
}
