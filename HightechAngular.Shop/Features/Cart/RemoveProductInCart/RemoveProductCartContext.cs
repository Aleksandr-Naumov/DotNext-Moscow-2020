using Force.Cqrs;
using HightechAngular.Core.Entities;
using HightechAngular.Web.Features.Cart;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Cart
{
    public class RemoveProductCartContext : UpdateProductInCartContextBase<RemoveProductCart, bool>
    {
        public RemoveProductCartContext(RemoveProductCart request, Product product) : base(request, product)
        {
        }
    }
}
