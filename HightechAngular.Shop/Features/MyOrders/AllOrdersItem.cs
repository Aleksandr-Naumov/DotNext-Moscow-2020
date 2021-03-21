using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Force.Ddd;
using HightechAngular.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Admin.Features.OrderManagement
{
    public class AllOrdersItem : HasIdBase
    {
        [Display(Name = "Id")]
        public override int Id { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }
        
        [Display(Name = "Status")]
        public string Status { get; set; } = default!;

        [Display(Name = "Created")]
        public string Created { get; set; } = default!;

        [HiddenInput]
        public string UserId { get; set; } = default!;
    }
}