﻿using Force.Cqrs;
using HightechAngular.Orders.Entities;
using Infrastructure.Cqrs.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HightechAngular.Web.Features.Catalog.GetCategories
{
    public class GetCategoriesQueryHandler : GetIntEnumerableQueryHandlerBase<GetCategoriesQuery, Category, CategoryListItem>
    {
        public GetCategoriesQueryHandler(IQueryable<Category> queryable) : base(queryable)
        {
        }
    }
}