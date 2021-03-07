using System;
using System.Data.Common;
using System.Net.Http;
using System.Threading.Tasks;
using Force.Ccc;
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;
using Microsoft.Extensions.Logging;

namespace HightechAngular.Orders.Base
{
    public abstract class ChangeOrderStateHandlerBase<TCommand, TFrom, TTo> :
        IHandler<ChangeOrderStateContext<TCommand, TFrom>, Task<CommandResult<TTo>>>
        where TCommand : class, IHasOrderId
        where TFrom : Order.OrderStateBase
        where TTo : Order.OrderStateBase
    {
        private readonly ILogger<TCommand> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeOrderStateHandlerBase(IUnitOfWork unitOfWork, ILogger<TCommand> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<CommandResult<TTo>> Handle(ChangeOrderStateContext<TCommand, TFrom> input)
        {
            using var tr = _unitOfWork.BeginTransaction();
            try
            {
                await ChangeStateInRemoteSystem(input);
                var result = ChangeState(input);
                _unitOfWork.Commit();
                await tr.CommitAsync();
                return result;
            }
            catch (HttpRequestException e)
            {
                await tr.RollbackAsync();
                return e;
            }
            catch (TaskCanceledException e)
            {
                await tr.RollbackAsync();
                return e;
            }
            catch (DbException e)
            {
                return await DoRollbackRemoteSystem(input, e);
            }
        }

        private async Task<Exception> DoRollbackRemoteSystem(ChangeOrderStateContext<TCommand, TFrom> input,
            DbException originalException)
        {
            try
            {
                await RollbackRemoteSystem(input, originalException);
                return originalException;
            }
            catch (Exception e)
            {
                _logger.LogError(e,
                    $"Problem with order state rollback in the remote system. Order id is {input.Order.Id}");
                return e;
            }
        }

        protected abstract TTo ChangeState(ChangeOrderStateContext<TCommand, TFrom> input);

        protected abstract Task ChangeStateInRemoteSystem(ChangeOrderStateContext<TCommand, TFrom> input);

        protected abstract Task RollbackRemoteSystem(ChangeOrderStateContext<TCommand, TFrom> input, DbException e);
    }
}