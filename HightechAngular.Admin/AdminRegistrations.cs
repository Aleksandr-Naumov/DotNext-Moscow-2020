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

            services.AddStateOrder<PayOrderContext, PayOrder, Order.New, Order.Paid>();
            services.AddStateOrder<ShipOrderContext, ShipOrder, Order.Paid, Order.Shipped>();
            services.AddStateOrder<CompleteOrderAdminContext, CompleteOrderAdmin, Order.Disputed, Order.Complete>();
        }
    }
}