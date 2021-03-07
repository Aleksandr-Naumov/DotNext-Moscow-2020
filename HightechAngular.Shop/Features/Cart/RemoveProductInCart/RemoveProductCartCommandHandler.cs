using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Cart
{
    public class RemoveProductCartCommandHandler : 
        ICommandHandler<RemoveProductCartContext, bool>
    {
        private readonly ICartStorage _cartStorage;

        public RemoveProductCartCommandHandler(ICartStorage cartStorage)
        {
            _cartStorage = cartStorage;
        }
        public bool Handle(RemoveProductCartContext input)
        {
            var res = _cartStorage.Cart.TryRemoveProduct(input.Product.Id);
            _cartStorage.SaveChanges();
            return res;
        }
    }
}
