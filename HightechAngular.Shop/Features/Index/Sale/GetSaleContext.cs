using Force.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Index.Sale
{
    public class GetSaleContext :
        QueryByIntIdOperationContextBase<IEnumerable<SaleListItem>, GetSale>,
        IQuery<IEnumerable<SaleListItem>>
    {
        [Required]
        public GetSale Sale { get; }
        public GetSaleContext(GetSale request) : base(request)
        {
            Sale = request;
        }
    }
}
