using System.Security.Principal;
using Force.Ddd;

namespace HightechAngular.Core.Entities
{
    public class OrderSpecs
    {
        public static readonly OrderSpecs Instance = new OrderSpecs();
        private OrderSpecs()
        {
        }
        
        public Spec<Order> ByUserName(string userName) => 
            new Spec<Order>(x => x.User.UserName == userName);
    }
}