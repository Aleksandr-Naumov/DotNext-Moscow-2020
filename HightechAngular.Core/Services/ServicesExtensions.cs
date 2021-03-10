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
        public static void AddStateOrder<TCommand, TFrom, TTo>(this IServiceCollection services)
            where TCommand : ChangeStateOrderBase
            where TFrom : Order.OrderStateBase
            where TTo : Order.OrderStateBase
        {
            services.AddScoped<
                ICommandHandler<ChangeStateOrderContext<TCommand, TFrom>, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<TCommand, TFrom, TTo>>();
        }
    }
}