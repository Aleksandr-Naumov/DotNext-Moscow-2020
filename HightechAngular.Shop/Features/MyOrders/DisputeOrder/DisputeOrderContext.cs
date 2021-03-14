﻿using Force.Cqrs;
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
    public class DisputeOrderContext : OrderStatusContextBase<DisputeOrder>
    {
        [Required]
        public Order.Disputed ChangeOrderState => Order.With((Order.Shipped newOrder) => newOrder.BecomeDisputed())!;
        public DisputeOrderContext(DisputeOrder request, Order order) : base(request, order)
        {
        }
    }
}
