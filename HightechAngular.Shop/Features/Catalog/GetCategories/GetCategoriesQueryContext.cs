using Force.Cqrs;
using Infrastructure.OperationContext;
using System.Collections.Generic;

namespace HightechAngular.Web.Features.Catalog
{
    public class GetCategoriesQueryContext :
        QueryByIntIdOperationContextBase<IEnumerable<CategoryListItem>, GetCategoriesQuery>,
        IQuery<IEnumerable<CategoryListItem>>
    {
        public GetCategoriesQueryContext(GetCategoriesQuery request) : base(request)
        {
        }
    }
}