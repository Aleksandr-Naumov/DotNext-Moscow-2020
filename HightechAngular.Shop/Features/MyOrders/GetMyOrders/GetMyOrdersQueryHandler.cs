using Force.Cqrs;
using HightechAngular.Identity.Services;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders.GetMyOrders;
using HightechAngular.Web.Features.MyOrders;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.Account
{
    [UsedImplicitly]
    public class GetMyOrdersQueryHandler : GetIntEnumerableQueryHandlerBase<GetMyOrders, Order, MyOrdersListItem>
    {
        public GetMyOrdersQueryHandler(IQueryable<Order> queryable) : base(queryable) { }
    }
}
