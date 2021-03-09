using Force.Cqrs;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CompleteOrderContext : OrderStatusContextBase<CompleteOrder>
    {
        public CompleteOrderContext(CompleteOrder request, Order order) : base(request, order)
        {
        }
    }
}
