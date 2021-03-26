using Force.Ddd.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService
{
    public class ProductPurchased : IDomainEvent
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime Happened { get; set; }
    }
}
