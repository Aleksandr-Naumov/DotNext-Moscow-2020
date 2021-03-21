using System;
using System.Collections.Generic;
using HightechAngular.Core.Entities;

namespace HightechAngular.Core.Services
{
    public class CartDto
    {
        public Guid Id { get; set; }

        public List<CartItem> CartItems { get; set; } = default!;
    }
}