using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Models.Dto;
using PiggyBank.Model;
using PiggyBank.Model.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Queries.Categories
{
    public class GetCategoriesQuery : BaseQuery<CategoryDto[]>
    {
        public GetCategoriesQuery(PiggyContext context)
            : base(context) { }

        public override Task<CategoryDto[]> Invoke()
            => GetRepository<Category>().Where(c => !c.IsDeleted)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                HexColor = c.HexColor,
                Title = c.Title,
                Type = c.Type
            }).ToArrayAsync();
    }
}
