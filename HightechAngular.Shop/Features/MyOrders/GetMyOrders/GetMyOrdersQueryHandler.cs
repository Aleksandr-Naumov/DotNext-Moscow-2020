﻿using Force.Cqrs;
using HightechAngular.Identity.Services;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    [UsedImplicitly]
    public class GetMyOrdersQueryHandler : GetIntEnumerableQueryHandlerBase<GetMyOrders, Order, MyOrdersListItem>
    {
        public GetMyOrdersQueryHandler(IQueryable<Order> queryable) : base(queryable) { }
    }
}
