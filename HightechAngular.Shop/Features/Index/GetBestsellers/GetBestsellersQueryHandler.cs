﻿using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.Index.GetBestsellers;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.Index.GetBestSellers
{
    public class GetBestsellersQueryHandler :
        IQueryHandler<GetBestsellersContext, IEnumerable<BestsellersListItem>>
    {
        private readonly IQueryable<Product> _products;
        public GetBestsellersQueryHandler(IQueryable<Product> products)
        {
            _products = products;
        }
        public IEnumerable<BestsellersListItem> Handle(GetBestsellersContext input) => 
            _products
                .Where(Product.Specs.IsBestseller)
                .ProjectToType<BestsellersListItem>()
                .ToList();
    }
}
