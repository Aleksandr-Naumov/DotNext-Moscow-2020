using Force.Ccc;
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
    public class PayOrderCommandHandler :
        ICommandHandler<PayOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        private readonly IQueryable<Order> _orders; 
        private readonly IUnitOfWork _unitOfWork;
        public PayOrderCommandHandler(
            IQueryable<Order> orders,
            IUnitOfWork unitOfWork)
        {
            _orders = orders;
            _unitOfWork = unitOfWork;
        }
        public async Task<HandlerResult<OrderStatus>> Handle(PayOrderContext input)
        {
            var order = _orders.First(x => x.Id == input.Order.Id);
            await Task.Delay(1000);
            var result = order.BecomePaid();
            _unitOfWork.Commit();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
