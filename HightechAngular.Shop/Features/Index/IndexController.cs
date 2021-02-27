using System;
using System.Collections.Generic;
using System.Linq;
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features.Index;
using HightechAngular.Shop.Features.Index.Bestsellers;
using HightechAngular.Shop.Features.Index.NewArrivals;
using HightechAngular.Shop.Features.Index.Sale;
using HightechAngular.Web.Features.Index.GetBestSellers;
using Infrastructure.AspNetCore;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Web.Features.Index
{
    [Route("api")]
    public class IndexController : ApiControllerBase
    {
        [HttpGet("Bestsellers")]
        public ActionResult<IEnumerable<BestsellersListItem>> Get([FromQuery] GetBestsellers query) =>
            this.Process(query);

        [HttpGet("NewArrivals")]
        [ProducesResponseType(typeof(IEnumerable<NewArrivalsListItem>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<NewArrivalsListItem>> Get([FromQuery] GetNewArrivals query) =>
            this.Process(query);

        [HttpGet("Sale")]
        public ActionResult<IEnumerable<SaleListItem>> Get([FromQuery] GetSale query) =>
            this.Process(query);
    }
}