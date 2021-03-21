using Force.Ccc;
using Force.Cqrs;
using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HightechAngular.Core.Base;
using HightechAngular.Shop.Features.MyOrders.Base;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class PayOrderCommandHandler : PayOrderCommandHandlerBase<PayOrder>
    {
        public PayOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
<<<<<<< HEAD
=======
        public async Task<HandlerResult<OrderStatus>> Handle(PayOrderContext input)
        {
            await Task.Delay(1000);
            var result = input.State.BecomePaid();
>>>>>>> master

        protected override Order.Paid ChangeStateOrder(ChangeStateOrderContext<PayOrder, Order.New> input)
        {
            return input.State.BecomePaid();
        }
    }
}