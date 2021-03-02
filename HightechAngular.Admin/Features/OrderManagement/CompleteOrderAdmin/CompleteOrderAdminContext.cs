﻿using Force.Cqrs;
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
    public class CompleteOrderAdminContext : BaseOrderStatusContext<CompleteOrderAdmin>
    {
        public CompleteOrderAdminContext(CompleteOrderAdmin request, Order order) : base(request, order)
        {
        }
    }
}