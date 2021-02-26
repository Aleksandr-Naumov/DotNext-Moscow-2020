using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using HightechAngular.Web.Features.Cart;
using HightechAngular.Web.Features.Catalog;
using HightechAngular.Web.Features.Index;
using Infrastructure.SwaggerSchema.Dropdowns.Providers;
using Microsoft.Extensions.DependencyInjection;
using HightechAngular.Shop.Features;
using HightechAngular.Shop.Features.Index.GetBestsellers;
using HightechAngular.Shop.Features.Index.NewArrivals;
using HightechAngular.Shop.Features.Index.Sale;

namespace HightechAngular.Shop
{
    public static class ShopRegistrations
    {
        public static void RegisterShop(this IServiceCollection services)
        {
            services.AddScoped<ICartStorage, CartStorage>();
            services.AddScoped<IDropdownProvider<ProductListItem>, ProductsDropdownProvider>();
            services.AddScoped<IDropdownProvider<BestsellersListItem>, BestsellersDropdownProvider>();
            services.AddScoped<IDropdownProvider<NewArrivalsListItem>, NewArrivalsDropdownProvider>();
            services.AddScoped<IDropdownProvider<SaleListItem>, SaleListDropdownProvider>();
            services.AddScoped<IDropdownProvider<CartItem>, CartDropdownProvider>();
        }
    }
}