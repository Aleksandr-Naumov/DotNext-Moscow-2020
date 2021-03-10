using System;
using System.Threading.Tasks;
using Force.Ccc;
using Force.Cqrs;
using Force.Extensions;
using HightechAngular.Core.Entities;
using HightechAngular.Shop.Features;
using Infrastructure.Cqrs;
using Infrastructure.Workflow;
using Microsoft.Data.SqlClient;

namespace HightechAngular.Core.Base
{
    public abstract class DomainHandlerBase<TCommand, TFrom, TTo> :
        IHandler<ChangeStateOrderContext<TCommand, TFrom>, Task<HandlerResult<TTo>>>
        where TCommand : ChangeOrderStateBase
        where TFrom : Order.OrderStateBase
        where TTo : Order.OrderStateBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DomainHandlerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HandlerResult<TTo>> Handle(ChangeStateOrderContext<TCommand, TFrom> input)
        {
            using var tr = _unitOfWork.BeginTransaction();
            try
            {
                await Task.Delay(300);
                var result = ChangeStateOrder(input);

                _unitOfWork.Commit();
                await tr.CommitAsync();
                return result;
            }
            catch (Exception e)
            {
                await tr.RollbackAsync();
                return FailureInfo.Invalid(e.Message);
            }
        }

        public abstract TTo ChangeStateOrder(ChangeStateOrderContext<TCommand, TFrom> input);
    }
}