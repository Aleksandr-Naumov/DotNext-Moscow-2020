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

        protected override Order.Paid ChangeStateOrder(ChangeStateOrderContext<PayOrder, Order.New> input)
        {
            return input.State.BecomePaid();
        }
    }
}