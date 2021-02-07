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
    public class CompleteOrderAdminCommnadHandler :
        ICommandHandler<CompleteOrderAdmin, Task<HandlerResult<OrderStatus>>>
    {
        private readonly IQueryable<Order> _orders;
        public CompleteOrderAdminCommnadHandler(IQueryable<Order> orders)
        {
            _orders = orders;
        }
        public async Task<HandlerResult<OrderStatus>> Handle(CompleteOrderAdmin input)
        {
            var order = _orders.First(x => x.Id == input.OrderId);
            await Task.Delay(1000);
            var result = order.BecomeComplete();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
