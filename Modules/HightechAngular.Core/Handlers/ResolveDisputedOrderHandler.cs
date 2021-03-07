using Force.Ccc;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace HightechAngular.Orders.Handlers
{
    [UsedImplicitly]
    public class ResolveDisputedOrderHandler :
        CompleteOrderHandlerBase<ResolveDisputedOrder, Order.Disputed>
    {
        public ResolveDisputedOrderHandler(IUnitOfWork unitOfWork, ILogger<ResolveDisputedOrder> logger) :
            base(unitOfWork, logger) { }

        protected override Order.Complete ChangeState(
            ChangeOrderStateContext<ResolveDisputedOrder, Order.Disputed> input)
        {
            return input.State.Resolve(input.Request.ResolutionComment);
        }
    }
}