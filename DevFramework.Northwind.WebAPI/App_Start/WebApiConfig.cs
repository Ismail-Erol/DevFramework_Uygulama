using DevFramework.Northwind.WebAPI.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DevFramework.Northwind.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new AuthenticationHandler()); // yapılan her istekte token servisimiz çalışacak. 
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
