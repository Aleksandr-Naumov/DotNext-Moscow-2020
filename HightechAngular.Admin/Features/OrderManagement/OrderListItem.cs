using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Force.Ddd;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class OrderListItem : HasIdBase, IHasCreatedDateString
    {
        public static readonly Expression<Func<Order, OrderListItem>> Map = x => new OrderListItem()
        {
            Id = x.Id,
            Total = x.Total,
            Status = x.Status,
            Created = x.Created,
            UserName = x.User.Email,
            DisputeComment = x.Status == OrderStatus.Dispute ? Comment : ""
        };
        static OrderListItem()
        {
            TypeAdapterConfig<Order, OrderListItem>
                .NewConfig()
                .Map(dest => dest.UserName, src => src.User.Email)
                .Map(dest => dest.DisputeComment, src => src.Status == OrderStatus.Dispute
                    ? src.Complaint
                    : src.AdminComment);
        }

        [Display(Name = "Id")]
        public override int Id { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }

        [Display(Name = "Status")]
        public OrderStatus Status { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; } = default!;

        [Display(Name = "Created")]
        public string CreatedString => Created.ToString("d");

        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Display(Name = "Comment")]
        public string DisputeComment { get; set; }
        private const string Comment = "To do comments";
    }
}