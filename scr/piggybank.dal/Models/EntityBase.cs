using System;
using System.ComponentModel.DataAnnotations;

namespace piggybank.dal.Models
{
    public abstract class EntityBase
    {
        [Required]
        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
