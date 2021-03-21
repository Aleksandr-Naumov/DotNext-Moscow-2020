using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Force.Ddd;
using Force.Ddd.DomainEvents;
using Force.Extensions;
using HightechAngular.Identity.Entities;
using Infrastructure.Ddd;
using Infrastructure.Ddd.Domain.State;

namespace HightechAngular.Core.Entities
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public partial class Order : OrderHasStateBase<OrderStatus, Order.OrderStateBase>
    {
        public static readonly OrderSpecs Specs = OrderSpecs.Instance;
        private readonly static DomainEventStore _domainEvents = new DomainEventStore();
        protected Order()
        {
        }

        public Order(Cart cart)
        {
            User = cart.User ?? throw new InvalidOperationException("User must be authenticated");

            _orderItems = cart
                .CartItems
                .Select(x => new OrderItem(this, x))
                .ToList();

            Total = _orderItems.Select(x => x.Price).Sum();
            Status = OrderStatus.New;
            this.EnsureInvariant();
        }

        [Required]
        public virtual User User { get; protected set; } = default!;

        public DateTime Created { get; protected set; } = DateTime.UtcNow;

        public DateTime Updated { get; protected set; }

        private readonly List<OrderItem> _orderItems = new List<OrderItem>();

        public virtual IEnumerable<OrderItem> OrderItems => _orderItems;

        public double Total { get; protected set; }

        public Guid? TrackingCode { get; protected set; }

        public override OrderStateBase GetState(OrderStatus status)
        {
            return status switch
            {
                OrderStatus.New => new New(this),
                OrderStatus.Paid => new Paid(this),
                OrderStatus.Shipped => new Shipped(this),
                OrderStatus.Dispute => new Disputed(this),
                OrderStatus.Complete => new Complete(this),

                _ => throw new NotSupportedException($"Status \"{status}\" is not supported")
            };
        }
    }
}