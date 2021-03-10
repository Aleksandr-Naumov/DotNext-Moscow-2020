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
using HightechAngular.Shop.Features.MyOrders;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminCommandHandler :
        DomainHandlerBase<
            CompleteOrderAdmin,
            Order.Disputed,
            Order.Complete>
    {
        public CompleteOrderAdminCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override Order.Complete ChangeStateOrder(ChangeStateOrderContext<CompleteOrderAdmin, Order.Disputed> input)
        {
            return input.State.BecomeComplete();
        }
    }
}
