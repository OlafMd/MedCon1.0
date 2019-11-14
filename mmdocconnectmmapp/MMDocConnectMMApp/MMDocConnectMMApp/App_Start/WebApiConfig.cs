using MMDocConnectMMApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MMDocConnectMMApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //apply authentication filter to all web API controllers
          /////////////////////////////////  config.Filters.Add(new AuthenticationFilter());
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
