﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Force.Ddd;
using HightechAngular.Core.Base;
using HightechAngular.Orders.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class OrderListItem : HasIdBase
    {
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
    }
}