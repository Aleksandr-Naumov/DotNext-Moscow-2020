using Force.Cqrs;
using HightechAngular.Core.Entities;
using HightechAngular.Shop.Features;
using Infrastructure.Cqrs;
using Infrastructure.OperationContext;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HightechAngular.Core.Base;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class ShipOrderContext : ChangeStateOrderContext<ShipOrder, Order.Paid>
    {
        [Required]
        public Order.Paid State => Order.As<Order.Paid>();
        public ShipOrderContext(ShipOrder request, Order order) : base(request, order)
        {
        }
    }
}
