using System.Collections.Generic;
using System.Linq;
using HightechAngular.Orders.Entities;
using HightechAngular.Web.Features.Shared;
using Infrastructure.AspNetCore;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Web.Features.Catalog
{
    public class CatalogController: ApiControllerBase
    {
        private readonly IQueryable<Category> _categories;
        private readonly IQueryable<Product> _products;

        public CatalogController(
            IQueryable<Category> categories,
            IQueryable<Product> products)
        {
            _categories = categories;
            _products = products;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductListItem>), StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] GetProducts query)
        {
            var products = _products
                .Where(x => x.Category.Id == query.CategoryId)
                .ProjectToType<ProductListItem>()
                .ToList();
            return Ok(products);
        }
        

        [HttpGet("GetCategories")]
        public IActionResult GetCategories()
        {
            return Ok(_categories);
        }
    }
}