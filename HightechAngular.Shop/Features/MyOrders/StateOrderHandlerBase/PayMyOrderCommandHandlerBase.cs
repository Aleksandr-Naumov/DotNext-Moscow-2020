using Force.Ccc;
using HightechAngular.Core.Base;
using HightechAngular.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders.Base
{
    public abstract class PayOrderCommandHandlerBase<TCommand> :
        DomainHandlerBase<
            TCommand,
            Order.New,
            Order.Paid>
        where TCommand : ChangeStateOrderBase
    {
        public PayOrderCommandHandlerBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
