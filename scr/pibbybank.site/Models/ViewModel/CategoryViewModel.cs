using piggybank.common.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace piggybank.site.Models.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        [Required]
        public string Title { get; set; }

        [DisplayName("Color")]
        public string HexColor { get; set; }

        [DisplayName("Show in")]
        public CategoryType CategoryType { get; set; }

        [DisplayName("Required")]
        public bool IsRequired { get; set; }

        public bool IsDeleted { get; set; }
    }
}
