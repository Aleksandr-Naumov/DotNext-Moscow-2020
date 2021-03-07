﻿using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;
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
            var result = input.Order.With((Order.Shipped newOrder) => newOrder.BecomeComplete());
            if (result == null)
            {
                return FailureInfo.Invalid("Order is in invalid state");
            }

            return result.EligibleStatus;
        }
    }
}
