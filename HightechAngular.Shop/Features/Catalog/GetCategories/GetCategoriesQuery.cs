using Force.Cqrs;
using Force.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Catalog
{
    public class GetCategoriesQuery : IQuery<IEnumerable<CategoryListItem>>
    {
    }
}
