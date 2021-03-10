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

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class PayOrderCommandHandler :
        DomainHandlerBase<
            PayOrder,
            Order.New,
            Order.Paid>
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