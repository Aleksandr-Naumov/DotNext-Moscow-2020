using Force.Cqrs;
using Force.Extensions;
using HightechAngular.Admin.Features.OrderManagement;
using HightechAngular.Orders.Entities;
using HightechAngular.Web.Features.MyOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.Admin
{
    //public class GetAllOrderQueryHandler :
    //    IQueryHandler<GetAllOrders, IEnumerable<AllOrdersItem>>
    //{
    //    private readonly IQueryable<Order> _orders;

    //    public GetAllOrderQueryHandler(IQueryable<Order> orders)
    //    {
    //        _orders = orders;
    //    }
    //    public IEnumerable<AllOrdersItem> Handle(GetAllOrders input)
    //    {
    //        _orders
    //            .Select(AllOrdersItem.Map)
    //            .ToList();
    //    }
    //}
}
