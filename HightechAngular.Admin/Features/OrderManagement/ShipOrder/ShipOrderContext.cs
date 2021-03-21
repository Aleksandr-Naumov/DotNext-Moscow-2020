using Force.Cqrs;
using HightechAngular.Orders.Entities;
using HightechAngular.Shop.Features;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderContext : OrderStatusContextBase<ShipOrder>
    {
        [Required]
        public Order.Paid State => Order.As<Order.Paid>();
        public ShipOrderContext(ShipOrder request, Order order) : base(request, order)
        {
        }
    }
}
