using System;
using System.Threading.Tasks;
using HightechAngular.Shop.Features.MyOrders;
using Infrastructure.SwaggerSchema.Dropdowns;
using Infrastructure.SwaggerSchema.Dropdowns.Providers;

namespace HightechAngular.Web.Features.OrderManagement
{
    public class PayOrderDropdownProvider : IDropdownProvider<PayMyOrder>
    {
        private readonly IServiceProvider _serviceProvider;

        public PayOrderDropdownProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<Dropdowns> GetDropdownOptionsAsync()
        {
            return _serviceProvider.DropdownsFor<PayMyOrder>();
        }
    }
}