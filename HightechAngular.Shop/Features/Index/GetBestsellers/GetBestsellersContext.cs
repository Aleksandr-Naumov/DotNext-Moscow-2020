using Force.Cqrs;
using Infrastructure.OperationContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Index.GetBestsellers
{
    public class GetBestsellersContext :
        QueryByIntIdOperationContextBase<IEnumerable<BestsellersListItem>, GetBestsellers>,
        IQuery<IEnumerable<BestsellersListItem>>
    {
        [Required]
        public GetBestsellers GetBestsellers { get; set; }
        public GetBestsellersContext(GetBestsellers request) : base(request)
        {
            GetBestsellers = request;
        }
    }
}
