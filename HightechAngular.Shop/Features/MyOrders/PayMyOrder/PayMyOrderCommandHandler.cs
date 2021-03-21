using Force.Ccc;
using Force.Cqrs;
using HightechAngular.Core.Entities;
using HightechAngular.Shop.Features.MyOrders;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HightechAngular.Core.Base;
using HightechAngular.Shop.Features.MyOrders.Base;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayMyOrderCommandHandler : PayOrderCommandHandlerBase<PayMyOrder>
    {
        public PayMyOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
<<<<<<< HEAD
=======
        public async Task<HandlerResult<OrderStatus>> Handle(PayMyOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.State.BecomePaid();
>>>>>>> master

        protected override Order.Paid ChangeStateOrder(ChangeStateOrderContext<PayMyOrder, Order.New> input)
        {
            return input.State.BecomePaid();
        }
    }
}