using piggybank.common.Enums;
using System;

namespace piggybank.dal.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string HexColor { get; set; }

        public CategoryType Type { get; set; }

        public bool IsRequired { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
