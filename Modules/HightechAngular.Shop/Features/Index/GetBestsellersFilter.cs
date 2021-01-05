﻿using System.Linq;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.Ddd;
using JetBrains.Annotations;

namespace HightechAngular.Shop.Features.Index
{
    [UsedImplicitly]
    public class GetBestsellersFilter : IFilter<Product, GetBestsellers>
    {
        public IQueryable<Product> Filter(IQueryable<Product> queryable, GetBestsellers predicate)
        {
            return queryable.Where(x => x.Price > 0 && x.PurchaseCount > 10);
        }
    }
}