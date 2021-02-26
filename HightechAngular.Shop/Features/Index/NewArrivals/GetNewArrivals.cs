using Force.Cqrs;
using Force.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Index.NewArrivals
{
    public class GetNewArrivals : FilterQuery<NewArrivalsListItem>, IHasId<int>
    {
        public int Id { get; set; }

        object IHasId.Id { get; }
        public override IOrderedQueryable<NewArrivalsListItem> Sort(IQueryable<NewArrivalsListItem> queryable)
        {
            if (Order == "dateCreated")
            {
                return Asc ? queryable.OrderByDescending(x => x.DateCreated) : queryable.OrderBy(x => x.DateCreated);
            }
            return base.Sort(queryable);
        }
    }
}
