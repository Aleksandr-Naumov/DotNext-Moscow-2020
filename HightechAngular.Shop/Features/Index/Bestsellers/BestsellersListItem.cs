﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Force.Ddd;
using HightechAngular.Core.Entities;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace HightechAngular.Shop.Features.Index.Bestsellers
{
    public class BestsellersListItem: HasIdBase
    {
        static BestsellersListItem()
        {
            TypeAdapterConfig<Product, BestsellersListItem>
                .NewConfig()
                .Map(dest => dest.Price, Product.DiscountedPriceExpression)
                .Map(dest => dest.DateCreatedName, src => src.DateCreated.ToString("d"));
        }

        [Display(Name = "Id")]
        public override int Id { get; set; }
        
        [Display(Name = "Name")]
        public string Name { get; set; } = default!;

        [Display(Name = "Category")]
        public string CategoryName { get; set; } = default!;

        [Display(Name = "Price")]
        public double Price { get; set; }
        
        [Display(Name = "Discount Percent")]
        public int DiscountPercent { get; set; }
        
        [Display(Name = "Date Created")]
        public string DateCreatedName { get; set; } = default!;

        [HiddenInput]
        public DateTime DateCreated { get; set; }
    }
}