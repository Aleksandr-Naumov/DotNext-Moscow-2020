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
            public OrderStateBase(Order order)
            {
                Order = order;
            }
            public OrderStateBase GetStateOrder(OrderStatus status)
            {
                return status switch
                {
                    OrderStatus.New => new New(Order),
                    OrderStatus.Paid => new Paid(Order),
                    OrderStatus.Shipped => new Shipped(Order),
                    OrderStatus.Dispute => new Disputed(Order),
                    OrderStatus.Complete => new Complete(Order),
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
            public Paid BecomePaid()
            {
                Order.Status = OrderStatus.Paid;
                return (Paid)GetStateOrder(Order.Status);
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
            public Shipped BecomeShipped()
            {
                Order.Status = OrderStatus.Shipped;
                return (Shipped)GetStateOrder(Order.Status);
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
            public Disputed BecomeDispute()
            {
                Order.Status = OrderStatus.Dispute;
                return (Disputed)GetStateOrder(Order.Status);
            }
            public Complete BecomeComplete()
            {
                Order.Status = OrderStatus.Complete;
                return (Complete)GetStateOrder(Order.Status);
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
            public Complete BecomeComplete()
            {
                Order.Status = OrderStatus.Complete;
                return (Complete)GetStateOrder(Order.Status);
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