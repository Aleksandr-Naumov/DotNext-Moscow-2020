using Force.Cqrs;
using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Force.Ccc;
using HightechAngular.Core.Base;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderCommandHandler :
        DomainHandlerBase<
            ShipOrder,
            Order.Paid,
            Order.Shipped>
    {
        public ShipOrderCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Order.Shipped ChangeStateOrder(ChangeStateOrderContext<ShipOrder, Order.Paid> input)
        {
            return input.State.BecomeShipped();
        }
    }
}