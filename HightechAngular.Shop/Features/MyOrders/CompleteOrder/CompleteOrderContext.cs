using HightechAngular.Core.Base;
using HightechAngular.Core.Entities;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CompleteOrderContext : ChangeStateOrderContext<CompleteOrder, Order.Shipped>
    {
        [Required]
        public Order.Shipped State => Order.As<Order.Shipped>();
        public CompleteOrderContext(CompleteOrder request, Order order) : base(request, order)
        {
        }
    }
}