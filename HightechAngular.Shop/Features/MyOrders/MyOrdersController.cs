using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HightechAngular.Core.Base;
using HightechAngular.Core.Entities;
using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class MyOrdersController : ApiControllerBase
    {
        [HttpPost("CreateNew")]
        [Authorize]
        public ActionResult<int> CreateNew([FromBody] CreateOrder query) =>
            this.Process(query);

        [HttpGet("GetMyOrders")]
        public ActionResult<IEnumerable<MyOrdersListItem>> GetMyOrders([FromQuery] GetMyOrders query) =>
            this.Process(query);

        [HttpPut("Dispute")]
        public async Task<IActionResult> Dispute(
            [FromServices] Func<DisputeOrder, DisputeOrderContext> factory,
            [FromBody] DisputeOrder command) =>
            await this.ProcessAsync(factory(command));

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete(
            [FromServices] Func<CompleteOrder, CompleteOrderContext> factory,
            [FromBody] CompleteOrder command) =>
            await this.ProcessAsync(factory(command));

        [HttpPut("PayOrder")]
        public async Task<IActionResult> PayOrder(
            [FromServices] Func<PayMyOrder, PayMyOrderContext> factory,
            [FromBody] PayMyOrder command) =>
            await this.ProcessAsync(factory(command));
    }
}