﻿using Force.Ccc;
using HightechAngular.Core.Services;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders.CreateNewOrder
{
    [UsedImplicitly]
    public class CreateOrderValidator : IValidator<CreateOrder>
    {
        private readonly ICartStorage _cartStorage;
        private static readonly ValidationResult CartIsEmpty = new ValidationResult("Cart is empty");

        public CreateOrderValidator(ICartStorage cartStorage)
        {
            _cartStorage = cartStorage;
        }

        public IEnumerable<ValidationResult> Validate(CreateOrder obj)
        {
            yield return _cartStorage.Cart.CartItems.Any()
                ? ValidationResult.Success
                : CartIsEmpty;
        }
    }
}
