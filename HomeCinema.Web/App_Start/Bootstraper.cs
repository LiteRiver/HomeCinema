using HomeCinema.Web.Infrastructure.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HomeCinema.Web {
    public class Bootstraper {
        public static void Run() {
            var cfg = GlobalConfiguration.Configuration;
            AutofacWebapiConfig.Initialize(cfg);

            cfg.MessageHandlers.Add(new HomeCinemaAuthHandler());

            cfg.MapHttpAttributeRoutes();

            cfg.Routes.MapHttpRoute(
                name: "DefaultApi", 
                routeTemplate: "api/{controller}/{id}", 
                defaults: new { id = RouteParameter.Optional });
        }
    }
}