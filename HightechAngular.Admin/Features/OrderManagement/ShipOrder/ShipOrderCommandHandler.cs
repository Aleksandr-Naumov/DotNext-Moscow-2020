using Force.Cqrs;
using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Orders.Entities;
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
            var result = input.ChangeOrderState;

            return result.EligibleStatus;
        }
    }
}
