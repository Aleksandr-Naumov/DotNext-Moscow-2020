using Force.Cqrs;
using HightechAngular.Core.Base;
using HightechAngular.Core.Entities;
using HightechAngular.Shop.Features.MyOrders;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using HightechAngular.Core.Services;
using HightechAngular.Shop.Features;

namespace HightechAngular.Shop
{
    public static class OrderRegistration
    {
        public static void RegisterOrder(this IServiceCollection services)
        {
            //services.AddStateOrder<CompleteOrder, Order.Shipped, Order.Complete>();
            //services.AddStateOrder<DisputeOrder, Order.Shipped, Order.Disputed>();
            //services.AddStateOrder<PayMyOrder, Order.New, Order.Paid>();

            services.AddScoped<
                ICommandHandler<CompleteOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<CompleteOrder, Order.Shipped, Order.Complete>>();

            services.AddScoped<
                ICommandHandler<DisputeOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<DisputeOrder, Order.Shipped, Order.Disputed>>();

            services.AddScoped<
                ICommandHandler<PayMyOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<PayMyOrder, Order.New, Order.Paid>>();

            //services.AddScoped(typeof(ChangeStateOrderContext<CompleteOrder, Order.Shipped>));
            //services.AddScoped(typeof(ChangeStateOrderContext<DisputeOrder, Order.Shipped>));
            //services.AddScoped(typeof(ChangeStateOrderContext<PayMyOrder, Order.New>));
            //services.AddScoped(typeof(CompleteOrderContext),
            //    typeof(ChangeStateOrderContext<CompleteOrder, Order.Shipped>));
            //services.AddScoped(typeof(DisputeOrderContext),
            //    typeof(ChangeStateOrderContext<DisputeOrder, Order.Shipped>));
            //services.AddScoped(typeof(PayMyOrderContext),
            //    typeof(ChangeStateOrderContext<PayMyOrder, Order.New>));
            //services.AddScoped(typeof(Func<CompleteOrder, ChangeStateOrderContext<CompleteOrder, Order.Shipped>>),
            //    x => ((dynamic)x.GetService(typeof(CompleteOrderContext))).BuildFunc(x));
            //services.AddScoped(typeof(Func<DisputeOrder, ChangeStateOrderContext<DisputeOrder, Order.Shipped>>),
            //    x => ((dynamic)x.GetService(typeof(DisputeOrderContext))).BuildFunc(x));
            //services.AddScoped(typeof(Func<PayMyOrder, ChangeStateOrderContext<PayMyOrder, Order.New>>),
            //    x => ((dynamic)x.GetService(typeof(PayMyOrderContext))).BuildFunc(x));
            //services.AddScoped<ChangeStateOrderContext<CompleteOrder, Order.Shipped>, CompleteOrderContext>();
            //services.AddScoped<ChangeStateOrderContext<DisputeOrder, Order.Shipped>, DisputeOrderContext>();
            //services.AddScoped<ChangeStateOrderContext<PayMyOrder, Order.New>, PayMyOrderContext>();

        }
    }
}