﻿using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Orders.Entities;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Cart
{
    public class BaseUpdateProductCartContext<TIn, TOut> :
        ByIntIdOperationContextBase<TIn>,
        ICommand<TOut>
        where TIn : class, IHasId<int>
    {
        [Required]
        public Product Product { get; }
        public BaseUpdateProductCartContext(TIn request, Product product) : base(request)
        {
            Product = product;
        }
    }
}
