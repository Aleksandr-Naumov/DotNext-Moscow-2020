using Force.Cqrs;
using Force.Ddd;
using HightechAngular.Shop.Features.Index.Bestsellers;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features
{
    public class GetContext<TIn, TOut> :
        QueryByIntIdOperationContextBase<IEnumerable<TOut>, TIn>,
        IQuery<IEnumerable<TOut>>
        where TIn : class, IHasId<int>
    {
        public GetContext(TIn request) : base(request)
        {
        }
    }
}
