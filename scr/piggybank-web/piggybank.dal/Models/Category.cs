using piggybank.dal.Enums;
using System.ComponentModel.DataAnnotations;

namespace piggybank.dal.Models
{
    public class Category : EntityBase, IBaseModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        public string HexColor { get; set; }

        public CategoryType Type { get; set; }

        public bool IsRequired { get; set; }

        public bool IsDeleted { get; set; }
    }
}
