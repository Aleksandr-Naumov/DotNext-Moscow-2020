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

namespace HightechAngular.Admin
{
    public static class AdminRegistrations
    {
        public static void RegisterAdmin(this IServiceCollection services)
        {
            services.AddScoped<IDropdownProvider<PayOrder>, PayOrderDropdownProvider>();
            services.AddScoped<IDropdownProvider<OrderListItem>, OrderListItemDropdownProvider>();
            services.AddScoped<IDropdownProvider<AllOrdersItem>, CreateOrderDropdownProvider>();
            PayAdminOrder(services);
            ShipOrder(services);
            CompleteAdminOrder(services);
        }

        private static void PayAdminOrder(this IServiceCollection services)
        {
            services.AddScoped<
                ICommandHandler<PayOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<PayOrder, Order.New, Order.Paid>>();
        }

        private static void ShipOrder(this IServiceCollection services)
        {
            services.AddScoped<
                ICommandHandler<ShipOrderContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<ShipOrder, Order.Paid, Order.Shipped>>();
        }

        private static void CompleteAdminOrder(this IServiceCollection services)
        {
            services.AddScoped<
                ICommandHandler<CompleteOrderAdminContext, Task<HandlerResult<OrderStatus>>>,
                ChangeOrderStateCommandHandler<CompleteOrderAdmin, Order.Disputed, Order.Complete>>();
        }
    }
}