using System.ComponentModel.DataAnnotations;
using Infrastructure.Ddd;
using JetBrains.Annotations;

namespace HightechAngular.Orders.Entities
{
    public class OrderItem : IntEntityBase
    {
        [UsedImplicitly]
        protected OrderItem() { }

        internal OrderItem(Order order, CartItem cartItem)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            Order = order;
            Count = cartItem.Count;
            Name = cartItem.ProductName;
            Price = cartItem.Price;
            ProductId = cartItem.ProductId;
        }

        [Required]
        public string Name { get; protected set; } = default!;

        public virtual Order Order { get; protected set; } = default!;

        public double Price { get; protected set; }

        public int Count { get; protected set; }

        public int ProductId { get; protected set; }
    }
}