using Force.Cqrs;
using HightechAngular.Identity.Services;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    [UsedImplicitly]
    public class GetMyOrdersQueryHandler : GetIntEnumerableQueryHandlerBase<GetMyOrdersContext, Order, MyOrdersListItem>
    {
        public GetMyOrdersQueryHandler(IQueryable<Order> queryable) : base(queryable) { }
    }
}
