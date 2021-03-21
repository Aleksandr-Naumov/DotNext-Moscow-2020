using Force.Ccc;
using Force.Cqrs;
using HightechAngular.Core.Entities;
using HightechAngular.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrder, int>
    {
        private readonly ICartStorage _cartStorage;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(
            ICartStorage cartStorage,
            IUnitOfWork unitOfWork)
        {
            _cartStorage = cartStorage;
            _unitOfWork = unitOfWork;
        }
        public int Handle(CreateOrder input)
        {
            var order = new Order(_cartStorage.Cart);

            _unitOfWork.Add(order);
            _unitOfWork.Commit();
            _cartStorage.EmptyCart();

            return order.Id;
        }
    }
}
