using System.Threading.Tasks;
using Force.Cqrs;
using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Core.Base;
using HightechAngular.Core.Entities;
using HightechAngular.Shop.Features.MyOrders;
using HightechAngular.Web.Features.OrderManagement;
using Infrastructure.Cqrs;
using Infrastructure.SwaggerSchema.Dropdowns.Providers;
using Microsoft.Extensions.DependencyInjection;
using HightechAngular.Core.Services;

namespace HightechAngular.Admin
{
    public static class AdminRegistrations
    {
        public static void RegisterAdmin(this IServiceCollection services)
        {
            services.AddScoped<IDropdownProvider<PayOrder>, PayOrderDropdownProvider>();
            services.AddScoped<IDropdownProvider<OrderListItem>, OrderListItemDropdownProvider>();
            services.AddScoped<IDropdownProvider<AllOrdersItem>, CreateOrderDropdownProvider>();

            // services.AddStateOrder<PayOrder,Order.New,Order.Paid>();
            // services.AddStateOrder<ShipOrder, Order.Paid, Order.Shipped>();
            // services.AddStateOrder<CompleteOrderAdmin, Order.Disputed, Order.Complete>();

            services.AddScoped<
                ICommandHandler<PayOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<PayOrder, Order.New, Order.Paid>>();

            services.AddScoped<
                ICommandHandler<ShipOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<ShipOrder, Order.Paid, Order.Shipped>>();

            services.AddScoped<
                ICommandHandler<CompleteOrderAdminContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<CompleteOrderAdmin, Order.Disputed, Order.Complete>>();

            // services.AddScoped<ChangeStateOrderContext<PayOrder, Order.New>, PayOrderContext>();
            // services.AddScoped<ChangeStateOrderContext<ShipOrder, Order.Paid>, ShipOrderContext>();
            // services.AddScoped<ChangeStateOrderContext<CompleteOrderAdmin, Order.Disputed>, CompleteOrderAdminContext>();
        }
    }
}