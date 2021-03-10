using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HightechAngular.Core.Base;

namespace HightechAngular.Shop.Features
{
    public class OrderStatusContextBase<T> :
        ByIntIdOperationContextBase<T>,
        ICommand<Task<HandlerResult<OrderStatus>>>
        where T : ChangeStateOrderBase
    {
        [Required]
        public Order Order { get; }

        public OrderStatusContextBase(T request, Order order) : base(request)
        {
            Order = order;
        }
    }
}
