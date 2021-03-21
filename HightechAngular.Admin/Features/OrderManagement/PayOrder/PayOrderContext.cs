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

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class PayOrderContext : ChangeStateOrderContext<PayOrder, Order.New>
    {
        public PayOrderContext(PayOrder request, Order order) : base(request, order)
        {
        }
    }
}
