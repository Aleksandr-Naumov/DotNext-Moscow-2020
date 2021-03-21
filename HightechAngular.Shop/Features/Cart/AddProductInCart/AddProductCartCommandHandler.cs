using Force.Cqrs;
using HightechAngular.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Cart
{
    public class AddProductCartCommandHandler :
        ICommandHandler<AddProductCartContext, int>
    {
        private readonly ICartStorage _cartStorage;

        public AddProductCartCommandHandler(ICartStorage cartStorage)
        {
            _cartStorage = cartStorage;
        }

        public int Handle(AddProductCartContext input)
        {
            _cartStorage.Cart.AddProduct(input.Product);
            _cartStorage.SaveChanges();
            return input.Product.Id;
        }
    }
}
