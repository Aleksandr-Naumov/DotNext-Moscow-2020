using System;
using System.ComponentModel.DataAnnotations;

namespace HightechAngular.Orders.Entities
{
    public partial class Order
    {
        public abstract class OrderStateBase
        {
            [Required]
            public Order Order { get; }
            public OrderStatus OrderStatus { get; set; }
            public OrderStateBase(Order order)
            {
                Order = order;
            }
            public OrderStatus GetStateOrder(OrderStatus status)
            {
                return status switch
                {
                    OrderStatus.New => Order.Status = OrderStatus.New,
                    OrderStatus.Paid => Order.Status = OrderStatus.Paid,
                    OrderStatus.Shipped => Order.Status = OrderStatus.Shipped,
                    OrderStatus.Dispute => Order.Status = OrderStatus.Dispute,
                    OrderStatus.Complete => Order.Status = OrderStatus.Complete,
                    _ => throw new NotImplementedException()
                };
            }
        }
        public class New : OrderStateBase
        {
            public New(Order order) : base(order)
            {
                if (order.Status != OrderStatus.New)
                {
                    throw new ArgumentException();
                }
            }
            public OrderStatus BecomePaid()
            {
                Order.Status = OrderStatus.Paid;
                return Order.Status;
            }
        }
        public class Paid : OrderStateBase
        {
            public Paid(Order order) : base(order)
            {
                if (order.Status != OrderStatus.Paid)
                {
                    throw new ArgumentException();
                }
            }
            public OrderStatus BecomeShipped()
            {
                return GetStateOrder(OrderStatus.Shipped);
            }
        }
        public class Shipped : OrderStateBase
        {
            public Shipped(Order order) : base(order)
            {
                if (order.Status != OrderStatus.Shipped)
                {
                    throw new ArgumentException();
                }
            }
            public OrderStatus BecomeDispute()
            {
                return GetStateOrder(OrderStatus.Dispute);
            }
            public OrderStatus BecomeComplete()
            {
                return GetStateOrder(OrderStatus.Complete);
            }
        }
        public class Disputed : OrderStateBase
        {
            public Disputed(Order order) : base(order)
            {
                if (order.Status != OrderStatus.Dispute)
                {
                    throw new ArgumentException();
                }
            }
            public OrderStatus BecomeComplete()
            {
                return GetStateOrder(OrderStatus.Complete);
            }
        }
        public class Complete : OrderStateBase
        {
            public Complete(Order order) : base(order)
            {
                if (order.Status != OrderStatus.Complete)
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}