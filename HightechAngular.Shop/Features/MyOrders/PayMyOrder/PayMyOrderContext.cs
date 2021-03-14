using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class PayMyOrderContext : OrderStatusContextBase<PayMyOrder>
    {
        [Required]
        public Order.Paid ChangeOrderState => Order.With((Order.New newOrder) => newOrder.BecomePaid())!;
        public PayMyOrderContext(PayMyOrder request, Order order) : base(request, order)
        {
        }
    }
}
