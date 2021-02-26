using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Force.Ccc;
using Force.Cqrs;
using Force.Extensions;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.MyOrders;
using Infrastructure.AspNetCore;
using Infrastructure.Cqrs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class OrderController : ApiControllerBase
    {
        [HttpGet()]
        [ProducesResponseType(typeof(OrderListItem), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] GetAllOrders query) =>
            this.Process(query);

        [HttpGet("GetOrders")]
        [ProducesResponseType(typeof(AllOrdersItem), StatusCodes.Status200OK)]
        public IActionResult GetOrders(
            [FromServices] Func<GetMyOrders, GetMyOrdersContext> factory,
            [FromQuery] GetMyOrders query) =>
            this.Process(factory(query));

        [HttpPut("PayOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PayOrder(
            [FromServices] Func<PayOrder, PayOrderContext> factory,
            [FromBody] PayOrder command) =>
            await this.ProcessAsync(factory(command));

        [HttpPut("Shipped")]
        public async Task<IActionResult> Shipped(
            [FromServices] Func<ShipOrder, ShipOrderContext> factory,
            [FromBody] ShipOrder command) =>
            await this.ProcessAsync(factory(command));

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete(
            [FromServices] Func<CompleteOrderAdmin, CompleteOrderAdminContext> factory,
            [FromBody] CompleteOrderAdmin command) =>
            await this.ProcessAsync(factory(command));
    }
}