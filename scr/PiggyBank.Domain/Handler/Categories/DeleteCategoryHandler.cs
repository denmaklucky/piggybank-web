using Microsoft.EntityFrameworkCore;
using PiggyBank.Model;
using PiggyBank.Model.Models;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Handler.Categories
{
    public class DeleteCategoryHandler : BaseHandler<int>
    {
        public DeleteCategoryHandler(PiggyContext context, int command)
            : base(context, command) { }

        public override async Task Invoke()
        {
            var repository = GetRepository<Category>();
            var category = await repository
                .FirstOrDefaultAsync(c => c.Id == Command && !c.IsDeleted);

            if (category == null)
                return;

            category.IsDeleted = true;

            repository.Update(category);
        }
    }
}
