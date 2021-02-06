using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Force.Ccc;
using Force.Cqrs;
using HightechAngular.Identity.Services;
using HightechAngular.Orders.Entities;
using HightechAngular.Orders.Services;
using HightechAngular.Web.Features.Account;
using Infrastructure.AspNetCore;
using Infrastructure.Cqrs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Web.Features.MyOrders
{
    public class MyOrdersController : ApiControllerBase
    {
        [HttpPost("CreateNew")]
        [Authorize]
        public ActionResult<int> CreateNew(
            [FromServices] ICommandHandler<CreateOrder, int> handler,
            [FromBody] CreateOrder query)
        {
            return Ok(handler.Handle(query));
        }

        [HttpGet("GetMyOrders")]
        public ActionResult<IEnumerable<OrderListItem>> GetMyOrders(
            [FromServices] IQueryHandler<GetMyOrders, IEnumerable<OrderListItem>> handler,
            [FromQuery] GetMyOrders query)
        {
            return Ok(handler.Handle(query));
        }
        [HttpPut("Dispute")]
        public async Task<IActionResult> Dispute(
            [FromServices] ICommandHandler<DisputeOrder, Task<HandlerResult<OrderStatus>>> handler,
            [FromBody] DisputeOrder command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete(
            [FromServices]ICommandHandler<CompleteOrder,Task<HandlerResult<OrderStatus>>> handler,
            [FromBody] CompleteOrder command)
        {
            return Ok(await handler.Handle(command));
        }

        [HttpPut("PayOrder")]
        public async Task<IActionResult> PayOrder(
            [FromServices] ICommandHandler<PayMyOrder, Task<HandlerResult<OrderStatus>>> handler,
            [FromBody] PayMyOrder command)
        {
            return Ok(await handler.Handle(command));
        }
    }
}