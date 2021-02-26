using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Force.Ddd;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Shop.Features.MyOrders
{
    public class MyOrdersListItem : HasIdBase
    {
        [Display(Name = "Id")]
        public override int Id { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; } = default!;

        [Display(Name = "Created")]
        public string Created { get; set; } = default!;

        [Display(Name = "UserName")]
        public string UserName { get; set; } = default!;

        [Display(Name = "Comment")]
        public string DisputeComment { get; set; } = default!;
    }
}
