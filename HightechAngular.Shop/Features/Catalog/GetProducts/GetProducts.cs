using System.Linq;
using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Shop.Features;

namespace HightechAngular.Web.Features.Catalog
{
    public class GetProducts : FilterQuery<ProductListItem>, IHasId<int>
    {
        public string[]? Name { get; set; }
        public double[]? Price { get; set; }
        public int CategoryId { get; set; }

        public int Id { get; set; }

        object? IHasId.Id { get; }

        public GetProducts()
        {
            Order = "Id";
            CategoryId = 1;
        }

        public override IQueryable<ProductListItem> Filter(IQueryable<ProductListItem> queryable)
        {
            return base.Filter(queryable.Where(x => x.CategoryId == CategoryId));
        }

        public override IOrderedQueryable<ProductListItem> Sort(IQueryable<ProductListItem> queryable)
        {
            if (Order == "dateCreated")
            {
                return Asc ? queryable.OrderByDescending(x => x.DateCreated) : queryable.OrderBy(x => x.DateCreated);
            }
            return base.Sort(queryable);
        }
    }
}