﻿using System;
using System.Threading.Tasks;
using Infrastructure.SwaggerSchema.Dropdowns;
using Infrastructure.SwaggerSchema.Dropdowns.Providers;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class OrderListItemDropdownProvider : IDropdownProvider<OrderListItem>
    {
        private readonly IServiceProvider _serviceProvider;

        public OrderListItemDropdownProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<Dropdowns> GetDropdownOptionsAsync()
        {
            return _serviceProvider.DropdownsFor<OrderListItem>();
        }
    }
}