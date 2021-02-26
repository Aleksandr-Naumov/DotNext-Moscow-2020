using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs.Read;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.OrderManagement
{
    [UsedImplicitly]
    public class GetAllOrdersHandler : GetIntEnumerableQueryHandlerBase<GetAllOrdersContext, Order, OrderListItem>
    {
        public GetAllOrdersHandler(IQueryable<Order> queryable) : base(queryable)
        {
        }
    }
}
