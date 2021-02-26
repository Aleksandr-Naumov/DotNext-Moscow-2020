using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Index.Sale
{
    public class GetSaleQueryHandler :
        IQueryHandler<GetSaleContext, IEnumerable<SaleListItem>>
    {
        private readonly IQueryable<Product> _products;
        public GetSaleQueryHandler(IQueryable<Product> products)
        {
            _products = products;
        }
        public IEnumerable<SaleListItem> Handle(GetSaleContext input) =>
            _products
                .Where(x => x.DiscountPercent > 0)
                .ProjectToType<SaleListItem>()
                .ToList();
    }
}
