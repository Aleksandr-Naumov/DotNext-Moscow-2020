using Force.Cqrs;
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
    public class CompleteOrderAdminCommnadHandler :
        ICommandHandler<CompleteOrderAdminContext, Task<HandlerResult<OrderStatus>>>
    {
        public async Task<HandlerResult<OrderStatus>> Handle(CompleteOrderAdminContext input)
        {
            await Task.Delay(1000);
            var result = input.Order.With((Order.Disputed newOrder) => newOrder.BecomeComplete());
            if (result == null)
            {
                return FailureInfo.Invalid("Order is in invalid state");
            }

            return result.EligibleStatus;
        }
    }
}
