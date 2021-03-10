using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Force.Cqrs;
using HightechAngular.Core.Entities;
using HightechAngular.Shop.Features;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;

namespace HightechAngular.Core.Base
{
    public class ChangeStateOrderContext<TCommand, TState> :
        OrderStatusContextBase<TCommand>
        where TCommand : ChangeOrderStateBase
        where TState : Order.OrderStateBase
    {
        [Required]
        public TState State => Order.As<TState>();

        public ChangeStateOrderContext(TCommand request, Order order) : base(request, order)
        {
        }
    }
}