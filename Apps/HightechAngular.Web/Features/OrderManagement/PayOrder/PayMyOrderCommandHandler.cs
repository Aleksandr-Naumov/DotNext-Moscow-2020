using Force.Ccc;
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Web.Features.MyOrders;
using Infrastructure.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.Account
{
    public class PayMyOrderCommandHandler :
        ICommandHandler<PayMyOrder, Task<HandlerResult<OrderStatus>>>
    {
        private readonly IQueryable<Order> _orders; 
        private readonly IUnitOfWork _unitOfWork;
        public PayMyOrderCommandHandler(
            IQueryable<Order> orders,
            IUnitOfWork unitOfWork)
        {
            _orders = orders;
            _unitOfWork = unitOfWork;
        }
        public async Task<HandlerResult<OrderStatus>> Handle(PayMyOrder input)
        {
            var order = _orders.First(x => x.Id == input.OrderId);
            await Task.Delay(1000);
            var result = order.BecomePaid();
            _unitOfWork.Commit();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
