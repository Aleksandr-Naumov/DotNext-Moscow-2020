using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Force.Cqrs;
using Force.Extensions;
using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Web.Features.Cart
{
    public class CartController : ApiControllerBase
    {
        [HttpGet] 
        public ActionResult<List<CartItem>> Get([FromServices] ICartStorage storage) =>
            storage.Cart.CartItems.PipeTo(Ok);

        [HttpPut("Add")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public IActionResult Add([FromBody] int productId) =>
            this.Process(new AddProductCart() { ProductId = productId });

        [HttpPut("Remove")]
        public ActionResult<bool> Remove([FromBody] int productId) =>
            this.Process(new RemoveProductCart() { ProductId = productId });
    }
}