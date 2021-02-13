using Force.Cqrs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.Cart
{
    public class RemoveProductCart : ICommand<bool>
    {
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
    }
}
