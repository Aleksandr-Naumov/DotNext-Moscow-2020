using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.Catalog
{
    public class GetProductsQueryHandler :
        IQueryHandler<GetProductsContext, IEnumerable<ProductListItem>>
    {
        private readonly IQueryable<Product> _products;
        public GetProductsQueryHandler(IQueryable<Product> products)
        {
            _products = products;
        }
        public IEnumerable<ProductListItem> Handle(GetProductsContext input) =>
            _products
                .Where(x => x.Category.Id == input.Category.Id)
                .ProjectToType<ProductListItem>()
                .ToList();
    }
}
