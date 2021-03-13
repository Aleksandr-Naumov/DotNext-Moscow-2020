using Force.Ccc;
using HightechAngular.Core.Base;
using HightechAngular.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public abstract class CompleteOrderCommandHandlerBase<TCommand, TFrom> :
        DomainHandlerBase<
            TCommand,
            TFrom,
            Order.Complete>
        where TCommand : ChangeStateOrderBase
        where TFrom : Order.OrderStateBase
    {
        public CompleteOrderCommandHandlerBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
