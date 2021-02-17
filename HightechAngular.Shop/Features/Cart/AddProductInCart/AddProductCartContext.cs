﻿using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Web.Features.Cart;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Cart
{
    public class AddProductCartContext :
        ByIntIdOperationContextBase<AddProductCart>,
        ICommand<int>
    {
        [Required]
        public Product Product { get; set; }
        public AddProductCartContext(AddProductCart request, Product product) : base(request)
        {
            Product = product;
        }
    }
}
