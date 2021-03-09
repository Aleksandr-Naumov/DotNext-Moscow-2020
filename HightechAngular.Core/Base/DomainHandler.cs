using Force.Cqrs;
using HightechAngular.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HightechAngular.Core.Base
{
    class DomainHandler : IHandler<Order.OrderStateBase, Order.OrderStateBase>
    {
        public Order.OrderStateBase Handle(Order.OrderStateBase input)
        {
            throw new NotImplementedException();
        }
    }
}
