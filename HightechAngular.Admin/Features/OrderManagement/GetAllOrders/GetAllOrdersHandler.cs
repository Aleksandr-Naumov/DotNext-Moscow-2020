﻿using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.OrderManagement
{
    [UsedImplicitly]
    public class GetAllOrdersHandler : GetIntEnumerableQueryHandlerBase<GetAllOrders, Order, OrderListItem>
    {
        public GetAllOrdersHandler(IQueryable<Order> queryable) : base(queryable)
        {
        }
    }
}
