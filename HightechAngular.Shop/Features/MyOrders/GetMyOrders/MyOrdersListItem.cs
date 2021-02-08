using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Force.Ddd;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Shop.Features.MyOrders.GetMyOrders
{
    public class MyOrdersListItem : HasIdBase
    {
        public static readonly Expression<Func<Order, MyOrdersListItem>> Map = x => new MyOrdersListItem()
        {
            Id = x.Id,
            Total = x.Total,
            Status = x.Status.ToString(),
            Created = x.Created.ToString("d"),
            UserName = x.User.Email,
            DisputeComment = x.Status == OrderStatus.Dispute ? Comment : ""
        };

        [Display(Name = "Id")]
        public override int Id { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Created")]
        public string Created { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Comment")]
        public string DisputeComment { get; set; }

        private const string Comment = "To do comments";
    }
}
