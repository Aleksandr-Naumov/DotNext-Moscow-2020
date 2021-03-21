using System.Collections.Generic;
using HightechAngular.Core.Entities;

namespace HightechAngular.Core.Services
{
    public interface ICartStorage
    {
        Cart Cart { get; }
        void SaveChanges();
        void EmptyCart();
    }
}