using System.Collections.Generic;
using System.Linq;
using Force.Extensions;
using HightechAngular.Identity.Services;
using HightechAngular.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HightechAngular.Core.Services
{
    public class CartStorage : ICartStorage
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserContext _userContext;

        public CartStorage(IHttpContextAccessor accessor, IUserContext userContext)
        {
            _accessor = accessor;
            _userContext = userContext;
        }

        private Cart _cart = default!;
        private static readonly string _cartKey = "Cart";

        public Cart Cart =>
            _cart ??= _accessor
                          .HttpContext
                          .Session
                          .Get<CartDto>(_cartKey)
                          .PipeTo(x => x.FromDto(_userContext.User))
                      ?? new Cart(_userContext.User);

        public void SaveChanges()
        {
            if (_cart != null)
            {
                _accessor
                    .HttpContext
                    .Session
                    .Set(_cartKey, _cart.ToDto());
            }
        }

        public void EmptyCart()
        {
            _accessor
                .HttpContext
                .Session
                .Remove(_cartKey);
        }
    }
}