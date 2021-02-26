using Force.Cqrs;
using Force.Ddd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Index.GetBestsellers
{
    public class GetBestsellers : FilterQuery<BestsellersListItem>, IHasId<int>
    {
        public int Id { get; set; }

        object? IHasId.Id { get; }
    }
}
