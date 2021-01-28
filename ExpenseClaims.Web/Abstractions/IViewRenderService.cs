﻿using System.Threading.Tasks;

namespace ExpenseClaims.Web.Abstractions
{
    public interface IViewRenderService
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}