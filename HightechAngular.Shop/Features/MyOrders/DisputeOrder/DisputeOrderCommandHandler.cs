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
    public class DisputeOrderCommandHandler :
        DomainHandlerBase<
            DisputeOrder,
            Order.Shipped,
            Order.Disputed>
    {
        public DisputeOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Order.Disputed ChangeStateOrder(ChangeStateOrderContext<DisputeOrder, Order.Shipped> input)
        {
            return input.State.BecomeDisputed();
        }
    }
}