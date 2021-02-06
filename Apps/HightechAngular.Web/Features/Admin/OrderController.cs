using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Force.Ccc;
using Force.Cqrs;
using Force.Extensions;
using HightechAngular.Orders.Entities;
using HightechAngular.Web.Dto.OrderManagement;
using HightechAngular.Web.Features.MyOrders;
using Infrastructure.AspNetCore;
using Infrastructure.Cqrs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class OrderController : ApiControllerBase
    {
        private readonly IQueryable<Order> _orders;

        public OrderController(IQueryable<Order> orders)
        {
            _orders = orders;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<OrderListItem>), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] GetAllOrders query) =>
            _orders
                .Select(AllOrdersItem.Map)
                .PipeTo(Ok);

        [HttpPut("PayOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PayOrder(
            [FromServices] ICommandHandler<PayOrder, Task<HandlerResult<OrderStatus>>> handler,
            [FromBody] PayOrder command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpGet("GetOrders")]
        [ProducesResponseType(typeof(AllOrdersItem), StatusCodes.Status200OK)]
        public IActionResult GetOrders([FromQuery] GetMyOrders query) =>
            _orders
                .Select(AllOrdersItem.Map)
                .PipeTo(Ok);

        [HttpPut("Shipped")]
        public async Task<IActionResult> Shipped(
            [FromServices] ICommandHandler<ShipOrder, Task<HandlerResult<OrderStatus>>> handler,
            [FromBody] ShipOrder command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete(
            [FromServices] ICommandHandler<CompleteOrderAdmin, Task<HandlerResult<OrderStatus>>> handler,
            [FromBody] CompleteOrderAdmin command)
        {
            return Ok(await handler.Handle(command));
        }
    }
}