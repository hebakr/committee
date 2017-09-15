using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace Committes.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

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
                name: "users",
                routeTemplate: "api/users/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "get", controller = "Users" }
            );
            config.Routes.MapHttpRoute(
                name: "sectors",
                routeTemplate: "api/sectors/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "get", controller = "Sectors" }
            );
            config.Routes.MapHttpRoute(
                name: "Reports",
                routeTemplate: "api/reports/{action}/{id}",
                defaults: new { id = RouteParameter.Optional, action = "get", controller = "reports" }
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
