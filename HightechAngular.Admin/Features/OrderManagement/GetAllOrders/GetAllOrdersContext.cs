using Force.Cqrs;
using Infrastructure.OperationContext;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class GetAllOrdersContext :
        QueryByIntIdOperationContextBase<IEnumerable<OrderListItem>, GetAllOrders>,
        IQuery<IEnumerable<OrderListItem>>
    {
        public GetAllOrdersContext(GetAllOrders request) : base(request)
        {
        }
    }
}