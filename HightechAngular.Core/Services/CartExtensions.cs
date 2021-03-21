using System.Linq;
using HightechAngular.Identity.Entities;
using HightechAngular.Core.Entities;

namespace HightechAngular.Core.Services
{
    public static class CartExtensions
    {
        public static CartDto ToDto(this Cart cart) => new CartDto
        {
            Id = cart.Id,
            CartItems = cart.CartItems.ToList()
        };

        public static Cart? FromDto(this CartDto dto, User user)
        {
            if (dto == null)
                return null;
            return new Cart(dto.Id, dto.CartItems, user);
        }
    }
}