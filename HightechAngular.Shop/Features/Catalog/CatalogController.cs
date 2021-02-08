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
        public IActionResult Get([FromQuery] GetProducts query) =>
            this.Process(query);


        [HttpGet("GetCategories")]
        public IActionResult GetCategories() =>
            this.Process(new GetCategoriesQuery());
    }
}