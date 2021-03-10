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

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayMyOrderCommandHandler :
        DomainHandlerBase<
            PayMyOrder,
            Order.New,
            Order.Paid>
    {
        public PayMyOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override Order.Paid ChangeStateOrder(ChangeStateOrderContext<PayMyOrder, Order.New> input)
        {
            return input.State.BecomePaid();
        }
    }
}