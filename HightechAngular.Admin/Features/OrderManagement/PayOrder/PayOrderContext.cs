using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class PayOrderContext : OrderStatusContextBase<PayOrder>
    {
        [Required]
        public Order.Paid ChangeOrderState => Order.With((Order.New newOrder) => newOrder.BecomePaid())!;
        public PayOrderContext(PayOrder request, Order order) : base(request, order)
        {
        }
    }
}
