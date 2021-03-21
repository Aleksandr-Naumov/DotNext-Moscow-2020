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
            services.AddStateOrder<CompleteOrderContext, CompleteOrder, Order.Shipped, Order.Complete>();
            services.AddStateOrder<DisputeOrderContext, DisputeOrder, Order.Shipped, Order.Disputed>();
            services.AddStateOrder<PayMyOrderContext, PayMyOrder, Order.New, Order.Paid>();
        }
    }
}