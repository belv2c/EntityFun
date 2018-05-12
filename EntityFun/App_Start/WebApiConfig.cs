using EntityFun.Models;
using Microsoft.Restier.Providers.EntityFramework;
using Microsoft.Restier.Publishers.OData;
using Microsoft.Restier.Publishers.OData.Batch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Extensions;

namespace EntityFun
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            {
                // Web API configuration and services

                // Web API routes
                config.MapHttpAttributeRoutes();

                config.Filter().Expand().Select().OrderBy().MaxTop(null).Count();
                config.MapRestierRoute<EntityFrameworkApi<AppDbContext>>(
                    "restier",
                    "api/data",
                    new RestierBatchHandler(GlobalConfiguration.DefaultServer));

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
    }
}
