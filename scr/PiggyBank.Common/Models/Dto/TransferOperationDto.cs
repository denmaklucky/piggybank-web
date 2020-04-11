﻿using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Common.Models.Dto
{
    public class TransferOperationDto
    {
        [Required]
        public int From { get; set; }

        [Required]
        public int To { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string Comment { get; set; }
    }
}
