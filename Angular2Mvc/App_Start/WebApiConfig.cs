using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Angular2Mvc.App_Start
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "ApiByAction",
                routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{action}",
                defaults: new { action = "Get" }
            );

            config.Routes.MapHttpRoute(
               name: "ApiById",
               routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{id}",
               defaults: null,
               //defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^[0-9]+$" }
               );

            config.Routes.MapHttpRoute(
                name: "ApiByNameId",
                routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^[0-9]+$" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiByName",
                routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{action}/{name}",
                defaults: null,
                constraints: new { name = @"^[a-z]+$" }
            );
        }
    }
}