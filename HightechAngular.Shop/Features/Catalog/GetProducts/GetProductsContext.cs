using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features;
using Infrastructure.OperationContext;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Web.Features.Catalog
{
    public class GetProductsContext :
        QueryByIntIdOperationContextBase<IEnumerable<ProductListItem>, GetProducts>,
        IQuery<IEnumerable<ProductListItem>>
    {
        [Required]
        public Category Category { get; }
        public GetProductsContext(GetProducts request, Category category) : base(request)
        {
            Category = category;
        }
    }
}