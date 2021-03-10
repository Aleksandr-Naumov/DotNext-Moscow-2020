using Force.Cqrs;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Force.Ccc;
using HightechAngular.Core.Base;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CompleteOrderCommandHandler :
        DomainHandlerBase<
            CompleteOrder,
            Order.Shipped,
            Order.Complete>
    {
        public CompleteOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Order.Complete ChangeStateOrder(ChangeStateOrderContext<CompleteOrder, Order.Shipped> input)
        {
            return input.State.BecomeComplete();
        }
    }
}