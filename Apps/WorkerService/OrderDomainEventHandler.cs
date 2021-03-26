using Infrastructure.Cqrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkerService
{
    public class OrderDomainEventHandler : IGroupDomainEventHandler<IEnumerable<ProductPurchased>>
    {
        public void Handle(IEnumerable<ProductPurchased> input)
        {
            if (input != null) 
            {
                var dict = input.ToDictionary(x => x.ProductId, x => x.Count);

                Console.WriteLine(input.FirstOrDefault().ProductId);
            }
            
        }
    }
}
