using System;
using System.Collections.Generic;
using System.Linq;
using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features;
using Infrastructure.AspNetCore;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Web.Features.Catalog
{
    public class CatalogController : ApiControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductListItem>), StatusCodes.Status200OK)]
        public IActionResult Get(
            [FromServices] Func<GetProducts, GetProductsContext> factory,
            [FromQuery] GetProducts query) =>
            this.Process(factory(query));


        [HttpGet("GetCategories")]
        public IActionResult GetCategories([FromServices] Func<GetCategoriesQuery, GetCategoriesQueryContext> factory) =>
            this.Process(factory(new GetCategoriesQuery()));
    }
}