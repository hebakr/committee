using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Committes.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "committee",
                routeTemplate: "api/Committees/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "get", controller = "Committees" }
            );
            config.Routes.MapHttpRoute(
                name: "sectors",
                routeTemplate: "api/sectors/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "get", controller = "Sectors" }
            );
            config.Routes.MapHttpRoute(
                name: "Schools",
                routeTemplate: "api/schools/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "get", controller = "Schools" }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
