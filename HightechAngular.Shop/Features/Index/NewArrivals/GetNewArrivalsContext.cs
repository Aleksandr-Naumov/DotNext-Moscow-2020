using Force.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Index.NewArrivals
{
    public class GetNewArrivalsContext :
        QueryByIntIdOperationContextBase<IEnumerable<NewArrivalsListItem>, GetNewArrivals>,
        IQuery<IEnumerable<NewArrivalsListItem>>
    {
        [Required]
        public GetNewArrivals NewArrivals { get; set; }
        public GetNewArrivalsContext(GetNewArrivals request) : base(request)
        {
            NewArrivals = request;
        }
    }
}
