using System.Threading.Tasks;
using Force.Cqrs;
using HightechAngular.Identity.Entities;
using HightechAngular.Identity.Services;
using HightechAngular.Orders.Base;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class CompleteOrderByAdminCommandHandler: ICommandHandler<
        ChangeOrderStateContext<CompleteOrderByAdmin, Order.Shipped>,
        Task<CommandResult<OrderStatus>>>
    {
        private readonly IHandler<ChangeOrderStateContext<
                CompleteOrderByAdmin, Order.Shipped>, 
                Task<CommandResult<Order.OrderStateBase>>> _handler;

        private readonly IUserContext _userContext;

        public CompleteOrderByAdminCommandHandler(
            IHandler<
                ChangeOrderStateContext<CompleteOrderByAdmin,  Order.Shipped>, 
                Task<CommandResult<Order.OrderStateBase>>> handler,
            IUserContext userContext)
        {
            _handler = handler;
            _userContext = userContext;
        }


        public async Task<CommandResult<OrderStatus>> Handle(ChangeOrderStateContext<CompleteOrderByAdmin, Order.Shipped> input)
        {
            // TODO: error handling
            var res = await _handler.Handle(input).MapAsync(x => x.EligibleStatus);
            await UpdateOrderInfoInExternalSystem(_userContext.User!);
            return res;
        }

        private Task UpdateOrderInfoInExternalSystem(User user)
        {
            return Task.Delay(1000);
        }
    }
}