using Force.Cqrs;
using Force.Ddd;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class GetMyOrders : FilterQuery<MyOrdersListItem>, IHasId<int>
    {
        public int Id { get; set; }

        object? IHasId.Id { get; }
    }
}