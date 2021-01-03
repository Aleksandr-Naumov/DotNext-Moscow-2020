﻿using System.Collections.Generic;
using System.Linq;
using EFCore.BulkExtensions;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using JetBrains.Annotations;

namespace HightechAngular.Orders.DomainEventHandlers
{
    [UsedImplicitly]
    public class OrderDomainEventHandler : IGroupDomainEventHandler<IEnumerable<ProductPurchased>>
    {
        private readonly IQueryable<Product> _products;

        public OrderDomainEventHandler(IQueryable<Product> products)
        {
            _products = products;
        }

        public void Handle(IEnumerable<ProductPurchased> input)
        {
            var dict = input.ToDictionary(x => x.ProductId, x => x.Count);
        }
    }
}