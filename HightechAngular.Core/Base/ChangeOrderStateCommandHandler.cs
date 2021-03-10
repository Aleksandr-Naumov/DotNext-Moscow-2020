﻿using Force.Cqrs;
using Force.Extensions;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs;
using System.Threading.Tasks;

namespace HightechAngular.Core.Base
{
    public class ChangeOrderStateCommandHandler<TCommand, TFrom, TTo> :
        ICommandHandler<ChangeStateOrderContext<TCommand, TFrom>, Task<HandlerResult<OrderStatus>>>
        where TCommand : ChangeStateOrderBase
        where TFrom : Order.OrderStateBase
        where TTo : Order.OrderStateBase
    {
        private IHandler<ChangeStateOrderContext<TCommand, TFrom>, Task<HandlerResult<TTo>>> Handler { get; set; }

        public ChangeOrderStateCommandHandler(
            IHandler<
                ChangeStateOrderContext<TCommand, TFrom>,
                Task<HandlerResult<TTo>>> handler)
        {
            Handler = handler;
        }

        public Task<HandlerResult<OrderStatus>> Handle(ChangeStateOrderContext<TCommand, TFrom> input)
        {
            return Handler
                .Handle(input)
                .AwaitAndPipeTo(x =>
                    x.Match(
                        result => new HandlerResult<OrderStatus>(result.EligibleStatus), 
                        failure => failure));
        }
    }
}