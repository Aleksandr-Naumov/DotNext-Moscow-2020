﻿using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class PayOrderContext :
        ByIntIdOperationContextBase<PayOrder>,
        ICommand<Task<HandlerResult<OrderStatus>>>
    {
        [Required]
        public Order Order { get; }
        public PayOrderContext(PayOrder request, Order order) : base(request)
        {
            Order = order;
        }
    }
}
