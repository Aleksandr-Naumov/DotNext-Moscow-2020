using Force.Cqrs;
using Force.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Index.Sale
{
    public class GetSale : FilterQuery<SaleListItem>, IHasId<int>
    {
        public int Id { get; set; }

        object? IHasId.Id { get; }
        public override IOrderedQueryable<SaleListItem> Sort(IQueryable<SaleListItem> queryable)
        {
            if (Order == "dateCreated")
            {
                return Asc ? queryable.OrderByDescending(x => x.DateCreated) : queryable.OrderBy(x => x.DateCreated);
            }
            return base.Sort(queryable);
        }
    }
}
