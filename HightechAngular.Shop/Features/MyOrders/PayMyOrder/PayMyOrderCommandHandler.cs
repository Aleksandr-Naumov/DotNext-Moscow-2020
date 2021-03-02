using Force.Ccc;
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;
using Infrastructure.Cqrs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayMyOrderCommandHandler :
        ICommandHandler<PayMyOrderContext, Task<HandlerResult<OrderStatus>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PayMyOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<HandlerResult<OrderStatus>> Handle(PayMyOrderContext input)
        {
            await Task.Delay(1000);
            var result = new Order.Paid(input.Order).GetStateOrder(OrderStatus.Paid);
            _unitOfWork.Commit();
            return new HandlerResult<OrderStatus>(result);
        }
    }
}
