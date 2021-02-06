using Force.Cqrs;
using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.Admin
{
    public class ShipOrderCommandHandler :
        ICommandHandler<ShipOrder, Task<HandlerResult<OrderStatus>>>
    {
        private IQueryable<Order> _orders;
        public ShipOrderCommandHandler(IQueryable<Order> orders)
        {
            _orders = orders;
        }

        public async Task<HandlerResult<OrderStatus>> Handle(ShipOrder input)
        {
            var order = _orders.First(x => x.Id == input.OrderId);
            await Task.Delay(1000);
            var result = order.BecomeShipped();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
