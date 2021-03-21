using Force.Cqrs;
using HightechAngular.Core.Entities;
using HightechAngular.Shop.Features.Index.Bestsellers;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.Index.GetBestSellers
{
    public class GetBestsellersQueryHandler :
        IQueryHandler<GetBestsellers, IEnumerable<BestsellersListItem>>
    {
        private readonly IQueryable<Product> _products;
        public GetBestsellersQueryHandler(IQueryable<Product> products)
        {
            _products = products;
        }
        public IEnumerable<BestsellersListItem> Handle(GetBestsellers input) => 
            _products
                .Where(Product.Specs.IsBestseller)
                .ProjectToType<BestsellersListItem>()
                .ToList();
    }
}
