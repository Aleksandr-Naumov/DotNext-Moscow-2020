using Force.Cqrs;
using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminCommnadHandler :
        ICommandHandler<CompleteOrderAdminContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(CompleteOrderAdminContext input)
        {
            await Task.Delay(1000);
            var result = new Order.Disputed(input.Order).BecomeComplete();
            return new HandlerResult<OrderStatus>(result.EligibleStatus);
        }
    }
}
