using Force.Ddd.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace HightechAngular.Core.Entities
{
    public class ProductPurchased : IDomainEvent
    {
        public ProductPurchased(int productId, int count)
        {
            ProductId = productId;
            Count = count;
            Happened = DateTime.UtcNow;
        }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime Happened { get; set; }
    }
}
