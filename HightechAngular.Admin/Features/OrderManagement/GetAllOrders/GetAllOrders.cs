using Force.Cqrs;
using Force.Ddd;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class GetAllOrders : FilterQuery<OrderListItem>, IHasId<int>
    {
        public int Id { get; set; }

        object? IHasId.Id { get; }
    }
}