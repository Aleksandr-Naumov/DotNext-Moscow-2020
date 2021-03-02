using System;

namespace HightechAngular.Orders.Entities
{
    public partial class Order
    {
        public abstract class OrderStateBase
        {
            public Order Order { get; set; }
            public virtual OrderStatus OrderStatus { get; set; }
            public OrderStateBase(Order order)
            {
                Order = order;
            }
        }
        public class New : OrderStateBase
        {
            public New(Order order) : base(order)
            {
            }
            public override OrderStatus OrderStatus => this.Order.Status = OrderStatus.New;
        }
        public class Paid : OrderStateBase
        {
            public Paid(Order order) : base(order)
            {
            }
            public override OrderStatus OrderStatus => this.Order.Status = OrderStatus.Paid;
        }
        public class Shipped : OrderStateBase
        {
            public Shipped(Order order) : base(order)
            {
            }
            public override OrderStatus OrderStatus => this.Order.Status = OrderStatus.Shipped;
        }
        public class Disputed : OrderStateBase
        {
            public Disputed(Order order) : base(order)
            {
            }
            public override OrderStatus OrderStatus => this.Order.Status = OrderStatus.Dispute;
        }
        public class Complete : OrderStateBase
        {
            public Complete(Order order) : base(order)
            {
            }
            public override OrderStatus OrderStatus => this.Order.Status = OrderStatus.Complete;
        }
    }
}