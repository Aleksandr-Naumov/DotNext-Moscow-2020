using System.Threading.Tasks;
using Force.Cqrs;
using HightechAngular.Core.Base;
using HightechAngular.Core.Entities;
using Infrastructure.Cqrs;
using Microsoft.Extensions.DependencyInjection;

namespace HightechAngular.Core.Services
{
    public static class ServicesExtensions
    {
        public static void AddStateOrder<TContext, TCommand, TFrom, TTo>(this IServiceCollection services)
            where TContext : ChangeStateOrderContext<TCommand, TFrom>
            where TCommand : ChangeStateOrderBase
            where TFrom : Order.OrderStateBase
            where TTo : Order.OrderStateBase
        {
            services.AddScoped<
                ICommandHandler<TContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<TCommand, TFrom, TTo>>();
        }
    }
}