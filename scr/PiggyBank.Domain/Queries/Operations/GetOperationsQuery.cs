using Microsoft.EntityFrameworkCore;
using PiggyBank.Common.Models.Dto;
using PiggyBank.Model;
using PiggyBank.Model.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace PiggyBank.Domain.Queries.Operations
{
    public class GetOperationsQuery : BaseQuery<OperationDto[]>
    {
        public GetOperationsQuery(PiggyContext context)
            : base(context) { }

        public override Task<OperationDto[]> Invoke()
            => GetRepository<Operation>().Select(o => new OperationDto
            {
                Id = o.Id,
                Comment = o.Comment,
                Type = o.Type
            })
            .ToArrayAsync();
    }
}
