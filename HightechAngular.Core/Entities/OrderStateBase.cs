using System;

namespace HightechAngular.Orders.Entities
{
    public partial class Order
    {
        public abstract class OrderStateBase
        {
            public Order Order { get; set; }
            public OrderStatus OrderStatus { get; set; }
            public OrderStateBase(Order order)
            {
                Order = order;
            }
            public OrderStatus GetStateOrder(OrderStatus status)
            {
                return status switch
                {
                    OrderStatus.New => this.Order.Status = OrderStatus.New,
                    OrderStatus.Paid => this.Order.Status = OrderStatus.Paid,
                    OrderStatus.Shipped => this.Order.Status = OrderStatus.Shipped,
                    OrderStatus.Dispute => this.Order.Status = OrderStatus.Dispute,
                    OrderStatus.Complete => this.Order.Status = OrderStatus.Complete,
                    _ => throw new Exception()
                };
            }
        }
        public class New : OrderStateBase
        {
            public New(Order order) : base(order)
            {
            }
        }
        public class Paid : OrderStateBase
        {
            public Paid(Order order) : base(order)
            {
            }
        }
        public class Shipped : OrderStateBase
        {
            public Shipped(Order order) : base(order)
            {
            }
        }
        public class Disputed : OrderStateBase
        {
            public Disputed(Order order) : base(order)
            {
            }
        }
        public class Complete : OrderStateBase
        {
            public Complete(Order order) : base(order)
            {
            }
        }
    }
}