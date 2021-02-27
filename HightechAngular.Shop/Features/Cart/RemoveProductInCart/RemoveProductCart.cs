using Force.Cqrs;
using Force.Ddd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.Cart
{
    public class RemoveProductCart : HasIdBase, ICommand<bool>
    {
    }
}
