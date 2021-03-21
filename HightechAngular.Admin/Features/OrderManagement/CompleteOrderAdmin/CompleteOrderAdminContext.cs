using Force.Cqrs;
using HightechAngular.Core.Entities;
using HightechAngular.Shop.Features;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HightechAngular.Core.Base;
using HightechAngular.Shop.Features.MyOrders;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderAdminContext : ChangeStateOrderContext<CompleteOrderAdmin, Order.Disputed>
    {
        public CompleteOrderAdminContext(CompleteOrderAdmin request, Order order) : base(request, order)
        {
        }
    }
}