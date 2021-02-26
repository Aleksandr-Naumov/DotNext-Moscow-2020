using Force.Cqrs;
using Infrastructure.OperationContext;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class GetMyOrdersContext :
        QueryByIntIdOperationContextBase<IEnumerable<MyOrdersListItem>, GetMyOrders>,
        IQuery<IEnumerable<MyOrdersListItem>>
    {
        public GetMyOrdersContext(GetMyOrders request) : base(request)
        {
        }
    }
}