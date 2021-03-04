using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CompleteOrderCommandHandler :
        ICommandHandler<CompleteOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(CompleteOrderContext input)
        {
            await Task.Delay(1000);
            var result = new Order.Shipped(input.Order).BecomeComplete();
            return new HandlerResult<OrderStatus>(result.Order.Status);
        }
    }
}
