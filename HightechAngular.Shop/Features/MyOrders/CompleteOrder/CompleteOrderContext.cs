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
    public class CompleteOrderContext : OrderStatusContextBase<CompleteOrder>
    {
        [Required]
        public Order.Shipped State => (Order.Shipped)Order.State;
        public CompleteOrderContext(CompleteOrder request, Order order) : base(request, order)
        {
        }
    }
}
