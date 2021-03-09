﻿using Force.Cqrs;
using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderCommandHandler :
        ICommandHandler<ShipOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(ShipOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.Order.With((Order.Paid newOrder) => newOrder.BecomeShipped());
            if (result == null)
            {
                return FailureInfo.Invalid("Order is in invalid state");
            }

            return result.EligibleStatus;
        }
    }
}
