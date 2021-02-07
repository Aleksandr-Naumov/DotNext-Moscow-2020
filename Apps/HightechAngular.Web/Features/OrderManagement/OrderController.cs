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
        [HttpGet()]
        [ProducesResponseType(typeof(OrderListItem), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] GetAllOrders query) =>
            this.Process(query);

        [HttpPut("PayOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PayOrder([FromBody] PayOrder command) =>
            await this.ProcessAsync(command);

        [HttpGet("GetOrders")]
        [ProducesResponseType(typeof(AllOrdersItem), StatusCodes.Status200OK)]
        public IActionResult GetOrders([FromQuery] GetMyOrders query) =>
            this.Process(query);

        [HttpPut("Shipped")]
        public async Task<IActionResult> Shipped([FromBody] ShipOrder command) =>
            await this.ProcessAsync(command);

        [HttpPut("Complete")]
        public async Task<IActionResult> Complete([FromBody] CompleteOrderAdmin command) =>
            await this.ProcessAsync(command);
    }
}