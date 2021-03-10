using Force.Cqrs;
using HightechAngular.Core.Base;
using HightechAngular.Core.Entities;
using HightechAngular.Shop.Features.MyOrders;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace HightechAngular.Shop
{
    public static class OrderRegistration
    {
        public static void RegisterOrder(this IServiceCollection services)
        {
            services.AddScoped<
                ICommandHandler<CompleteOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<CompleteOrder, Order.Shipped, Order.Complete>>();
            
            services.AddScoped<
                ICommandHandler<DisputeOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<DisputeOrder, Order.Shipped, Order.Disputed>>();
           
            services.AddScoped<
                ICommandHandler<PayMyOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<PayMyOrder, Order.New, Order.Paid>>();
        }
    }
}