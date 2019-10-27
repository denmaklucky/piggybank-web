using PiggyBank.Common.Enums;
using PiggyBank.Model.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PiggyBank.Model.Models
{
    public class Category : EntityBase, IBaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string HexColor { get; set; }

        public CategoryType Type { get; set; }

        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }
    }
}
