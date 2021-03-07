using System.Data.Common;
using System.Threading.Tasks;
using Force.Ccc;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;

namespace HightechAngular.Orders.Handlers
{
    [UsedImplicitly]
    public class DisputeOrderHandler :
        ChangeOrderStateHandlerBase<DisputeOrder, Order.Shipped, Order.Disputed>
    {
        public DisputeOrderHandler(IUnitOfWork unitOfWork, ILogger<DisputeOrder> logger) : base(unitOfWork, logger) { }


        protected override Order.Disputed ChangeState(ChangeOrderStateContext<DisputeOrder, Order.Shipped> input)
        {
            return input.State.BecomeDisputed(input.Request.Complaint);
        }

        protected override async Task ChangeStateInRemoteSystem(
            ChangeOrderStateContext<DisputeOrder, Order.Shipped> input)
        {
            await Task.Delay(300); // Imitate API Request
        }

        protected override async Task RollbackRemoteSystem(ChangeOrderStateContext<DisputeOrder, Order.Shipped> input,
            DbException e)
        {
            await Task.Delay(300); // Imitate API Request
        }
    }
}