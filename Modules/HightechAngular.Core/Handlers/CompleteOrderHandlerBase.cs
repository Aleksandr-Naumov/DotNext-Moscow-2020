using System.Data.Common;
using System.Threading.Tasks;
using Force.Ccc;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using Microsoft.Extensions.Logging;

namespace HightechAngular.Orders.Handlers
{
    public abstract class CompleteOrderHandlerBase<TCommand, TFrom> :
        ChangeOrderStateHandlerBase<TCommand, TFrom, Order.Complete>
        where TFrom : Order.OrderStateBase
        where TCommand : class, IHasOrderId
    {
        public CompleteOrderHandlerBase(IUnitOfWork unitOfWork, ILogger<TCommand> logger) : base(unitOfWork, logger) { }

        protected override async Task ChangeStateInRemoteSystem(
            ChangeOrderStateContext<TCommand, TFrom> input)
        {
            await Task.Delay(300); // Imitate API Request
        }

        protected override async Task RollbackRemoteSystem(ChangeOrderStateContext<TCommand, TFrom> input,
            DbException e)
        {
            await Task.Delay(300); // Imitate API Request
        }
    }
}