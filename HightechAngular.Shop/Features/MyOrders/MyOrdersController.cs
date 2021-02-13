using System.Collections.Generic;
using System.Threading.Tasks;
using HightechAngular.Shop.Features.MyOrders;
using HightechAngular.Shop.Features.MyOrders.GetMyOrders;
using Infrastructure.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Web.Features.MyOrders
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
        public async Task<IActionResult> Dispute([FromBody] DisputeOrder command) =>
            await this.ProcessAsync(command);

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete([FromBody] CompleteOrder command) =>
            await this.ProcessAsync(command);

        [HttpPut("PayOrder")]
        public async Task<IActionResult> PayOrder([FromBody] PayOrder command) =>
            await this.ProcessAsync(command);
    }
}